using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Menu.Commands.ShowMenu
{
    public class ShowMenuCommand : IRequest<IEnumerable<TreeViewNode>>
    {
        public IEnumerable<TreeViewNode>? MenuDto { get; set; }
    }
}
