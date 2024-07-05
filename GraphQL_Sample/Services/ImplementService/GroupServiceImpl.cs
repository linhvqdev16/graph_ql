using System.Text.RegularExpressions;
using GraphQL_Sample.Models;
using GraphQL_Sample.PresentationLayer.InterfaceService;

namespace GraphQL_Sample.PresentationLayer.ImplementService;

public class GroupServiceImpl : IGroupService
{
    private readonly List<GroupModel> _groups = new()
    {
        new GroupModel()
        {
            GroupdId = 1, Name = "Group Name 1" , ShortName = "Short Name 1"
                
        },
        new GroupModel()
        {
            GroupdId = 2, Name = "Group Name 2" , ShortName = "Short Name 2"
                
        }
    };

    public IQueryable<GroupModel> GetAll()
    {
        return _groups.AsQueryable();
    }
}