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
            List<Entity> entitiesList = new List<Entity>() {new Entity(1, 0, "Root entity"), new Entity(2, 1, "Child of 1 entity"),
            new Entity(3, 1, "Child of 1 entity"), new Entity(4, 2, "Child of 2 entity"), new Entity(5, 4, "Child of 4 entity")};
            return entitiesList;
        }
        static public Dictionary<int, List<Entity>> ValuePairs(List<Entity> listEntity)//говно код
        {
            List<Entity> entities1 = new List<Entity>();
            Dictionary<int, List<Entity>> valuePairs = new Dictionary<int, List<Entity>>();
            for (int i = 0; i< listEntity.Count; i++)
            {
                entities1.Add(listEntity[i]);
                if (i != listEntity.Count - 1 && listEntity[i].ParentId == listEntity[i + 1].ParentId)
                {
                    continue;
                }
                valuePairs.Add(listEntity[i].ParentId, entities1);
                entities1 = new List<Entity>();
            }
            return valuePairs;
        }
    }
}
