using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObobDZBars
{
    class Entity
    {
        public int Id { set; get; }
        public int ParentId { set; get; }
        public string Name { set; get; }
        
        public Entity(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
        static public List<Entity> ListRet()
        {
            return new List<Entity>() {new Entity(1, 0, "Root entity"), new Entity(2, 1, "Child of 1 entity"),
            new Entity(3, 1, "Child of 1 entity"), new Entity(4, 2, "Child of 2 entity"), new Entity(5, 4, "Child of 4 entity")}; ;
        }
        static public Dictionary<int, List<Entity>> ValuePairs(List<Entity> listEntity)
        {
            Dictionary<int, List<Entity>> valuePairs = new Dictionary<int, List<Entity>>();
            for (int i = 0; i < listEntity.Count; i++)
            {
                List<Entity> entities = listEntity.Where(n => n.ParentId.Equals(i)).ToList();
                while (entities.Count == 0)
                {
                    i++;
                    entities = listEntity.Where(n => n.ParentId.Equals(i)).ToList();
                    continue;
                }
                valuePairs.Add(entities[0].ParentId, entities);
            }
            return valuePairs;
        }
    }
}
