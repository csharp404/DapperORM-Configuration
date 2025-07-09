using DapperORM.Entities;

namespace DapperORM.Dto
{
    public class MyMultipleData
    {
       public  List<company> companies { get; set; }
        
        public User user { get; set; }      
    }
}
