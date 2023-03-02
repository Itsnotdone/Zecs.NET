namespace Zecs{
    public class Query<T>{

        private List<Type> without;
        
        public Query(){
            without = new List<Type>();
        }
        public Query<T> Without<A>(){
            without.Add(typeof(A));
            return this;
        }

        public IEnumerable<T> Iter(World world)
        {
            foreach (var entity in world.entites)
            {   
                foreach(var component in without){
                    if (entity.HasComponent(component)){
                        goto main;
                    }
                }
                if (entity.HasComponents<T>()){
                    yield return entity.GetComponents<T>();
                }
                main: {}
            }
        }

    }

}

