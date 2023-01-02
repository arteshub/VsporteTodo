using Microsoft.AspNetCore.Mvc;
using VSporte.DataAccessLayer.Models.Interfaces;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.HelpEnums.BaseCRUDManipulation;
using VSporte.HelpEnums;
using Vsporte.HandlerServices.Services.DuplicateResolverService;

namespace Vsporte.BaseManipulationsWebApi.Controllers
{
    /// <summary>
    /// Универсальный класс для очищения базы данных (любой таблицы)
    /// от дубликатов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DuplicateResolverController : ControllerBase
    {

        /// <summary>
        /// контроллер для очистки таблицы БД от дублей
        /// </summary>
        /// <param name="strategyId">Флаг для выбора нужной стратегии</param>
        /// <param name="todoId">Флаг определения уровни сложности задания</param>
        /// <returns></returns>
        [HttpGet]
        public async Task DuplicateResolve(TodoIdChangerEnum todoId)
        {
            switch (todoId)
            {
                case TodoIdChangerEnum.Bad:
                    await DuplicateResolverService.DuplicateResolveBad();
                    break;
                case TodoIdChangerEnum.Good:
                    await DuplicateResolverService.DuplicateResolveGood();
                    break;
                case TodoIdChangerEnum.Perfect:
                    await DuplicateResolverService.DuplicateResolvePerfect();
                    break;
                default:
                    throw new ArgumentException("Invalid todoId value", nameof(todoId));
            }
        }
    }
}
