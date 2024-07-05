using System.Text.RegularExpressions;
using GraphQL_Sample.Models;

namespace GraphQL_Sample.PresentationLayer.InterfaceService;

public interface IGroupService
{
    IQueryable<GroupModel> GetAll();
}