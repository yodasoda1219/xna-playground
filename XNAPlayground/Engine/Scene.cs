using System.Collections;
using System.Collections.Generic;

namespace XNAPlayground.Engine
{
    public class Scene : IEnumerable<Entity>, ICollection<Entity>
    {
        internal Scene()
        {
            mEntities = new List<Entity>();
        }
        public void Clear() => mEntities.Clear();
        public void Add(Entity entity) => mEntities.Add(entity);
        public void RemoveAt(int index) => mEntities.RemoveAt(index);
        public bool Remove(Entity entity) => mEntities.Remove(entity);
        public bool Contains(Entity entity) => mEntities.Contains(entity);
        public void CopyTo(Entity[] entities, int index) => mEntities.CopyTo(entities, index);
        public bool IsReadOnly => false;
        public int Count => mEntities.Count;
        public Entity this[int index] => mEntities[index];
        public IEnumerator<Entity> GetEnumerator()
        {
            return mEntities.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private List<Entity> mEntities;
    }
}