using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;

namespace Application.UseCases.Menu.Commands.ShowMenu
{
    public class ShowMenuCommandHandler : IRequestHandler<ShowMenuCommand, IEnumerable<TreeViewNode>>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;
        public ShowMenuCommandHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }
        public async Task<IEnumerable<TreeViewNode>> Handle(ShowMenuCommand menu, CancellationToken cancellationToken)
        {
            var _comp = mapper.Map<IEnumerable<IrisSdCompany>>(modelContext.IrisSdCompanies.AsNoTracking().ToList());
            var _cat = mapper.Map<IEnumerable<IrisSdCategory>>(modelContext.IrisSdCategories.AsNoTracking().Include(x => x.SdServ).ToList());
            var _link = mapper.Map<IEnumerable<IrisSdGrpLink>>(modelContext.IrisSdGrpLinks.AsNoTracking().Include(o => o.GrpObj).Include(sla => sla.SdSla).ToList());
            var _obj = mapper.Map<IEnumerable<IrisSdGrpObj>>(modelContext.IrisSdGrpObjs.AsNoTracking().ToList());
            var _serv = mapper.Map<IEnumerable<IrisSdService>>(modelContext.IrisSdServices.AsNoTracking().Include(c => c.SdComp).ToList());
            var _sla = mapper.Map<IEnumerable<IrisSdSla>>(modelContext.IrisSdSlas.AsNoTracking().Include(cat => cat.SdCat).ToList());
            var _contr = mapper.Map<IEnumerable<Contractor>>(modelContext.Contractors.AsNoTracking().ToList());

            var _grpLink = _link.Where(l => l.SdSla.Equals(_sla.Select(s => s.Id))).Where(l => l.GrpObj.Equals(_obj.Select(o => o.Id)));

            var _grpobj = from link in _grpLink
                          join obj in _obj on
                          link.GrpObjId equals obj.Id
                          select obj;

            //IEnumerable<IrisSdGrpLink> irisSdGrpLinks = context.IrisSdGrpLinks.Include(link => link.SdSla).Include(link => link.GrpObj).AsEnumerable();


            //IEnumerable <IrisSdGrpObj> grpObj = from grpLink in irisSdGrpLinks
            //                                   join grpobj in irisSdGrpObjs on
            //                                   grpLink.GrpObjId equals grpobj.Id
            //                                   select grpobj;

            List<TreeViewNode> nodes = new List<TreeViewNode>();

            TreeViewNodeService viewNodeService = new TreeViewNodeService();

            List<TreeViewNodeService> nodeServ = new List<TreeViewNodeService>();

            #region Формирование дерева через Chield

            ///вывод компаний
            foreach (var comp in _comp)
            {
                TreeViewNode treeViewNode = new TreeViewNode
                {
                    id = comp.Id.ToString().Replace("\"", ""),
                    text = comp.NameIs.Replace("\"", ""),
                    chields = _serv.Where(i => i.SdCompId == comp.Id).Select(i => i.NameIs.Replace("\"", "")).ToArray(),
                    nodeServices = new List<TreeViewNodeService>()
                };

                foreach (var servOne in _serv.Where(i => i.SdCompId == Convert.ToInt64(treeViewNode.id)))
                {
                    treeViewNode.nodeServices.Add(new TreeViewNodeService
                    {
                        id = servOne.Id.ToString().Replace("\"", "") + "-" + servOne.Id.ToString().Replace("\"", ""),
                        chieldsSCompanise = _cat.Where(i => i.SdServId == servOne.Id).Select(i => i.NameIs.Replace("\"", "")).ToArray(),
                        text = servOne.NameIs.Replace("\"", "")
                    });
                };
                nodes.Add(treeViewNode);
            }
            menu.MenuDto = nodes;
            #endregion

            return menu.MenuDto.ToList();
        }
    }
}
