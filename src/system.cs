namespace Zecs{
    public class Schedule{
        private List<UpdateSystem> UpdateSystems;
        private List<SetupSystem> SetupSystems;

        public Schedule(){
            UpdateSystems = new List<UpdateSystem>();
            SetupSystems = new List<SetupSystem>();
        }

        public void UpdateSystem(UpdateSystem system){
            UpdateSystems.Add(system);
        }

        public void SetupSystem(SetupSystem system){
            SetupSystems.Add(system);
        }

        public void Update(World world){
            foreach (var system in UpdateSystems){
                system.Update(world);
            }
        }

        public void Setup(World world){
            foreach (var system in SetupSystems){
                system.Setup(world);
            }
        }
    }
    public abstract class UpdateSystem{       
        public abstract void Update(World world);
    }

    public abstract class SetupSystem{
        
        public abstract void Setup(World world);

    }
}