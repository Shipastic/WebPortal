# WebPortal
Create Web portal for employee with ASP.NET Core WebAPI and Angular 13
Проект корпоративного веб-портала на ASP.NET Core Web API с испльзованием Angular 13 для отображения во фронт.
Данный проект проектировался с уклоном в гексагональную архитектуру. Доменный слой имеет порты и адаптеры для взаимодействия с другими слоями.
Сервис авторизации и аутентификации реализован с использованием ASP.NET Core Identity, что упростило реализацию рабты с пользователями и их ролями.
Для авторизации исопльзуется JWT-token.
В дальнейшем данный токен передается во фронт и хранится в докальном хранилище до истечении сессии.
Реализована работа с базой данных Оракл 12 с использованием REST API через Entity Framework Core.
Работа с объектами из базы данных ведется через DTO-классы(automapper).
Также для реализован паттерн CQRS для работы с запросами к API(библиотека Mediatr).
В дальнейшем планируется подключить Redis для кэширования запросов на выборку данных из базы.
Также необходимо доработать визуальную часть с применением bootstrap.