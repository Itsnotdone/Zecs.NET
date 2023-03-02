namespace Zecs{
    public class World{
        public List<Entity> entites;

        public World(){
            entites=new List<Entity>();
        }

        public Entity Push(params Component[] components){
            var entity = new Entity(components);
            entites.Add(entity);
            return entity;
        }
    }
}