// using static BenKnights.Netwrix.Controllers.CoffeeMachineController;
// using static BenKnights.Netwrix.CoffeeMachine;

namespace BenKnights.Netwrix
{
    public class CoffeeMachine
    {
        public interface ICoffeeMachine
        {
            public bool IsOn { get; }
            public bool IsMakingCoffee { get; }
            public CoffeeMachine.State WaterLevelState { get; }
            public CoffeeMachine.State BeanFeedState { get; }
            public CoffeeMachine.State WasteCoffeeState { get; }
            public CoffeeMachine.State WaterTrayState { get; }
            public Task TurnOnAsync();
            public Task TurnOffAsync();
            public Task MakeCoffeeAsync(CoffeeCreationOptions options);
        }

        public CoffeeMachine(bool _isOn, bool _isMakingCoffee, State _waterLevelState, State _beanFeedState, State _wasteCoffeeState, State _waterTryState) 
        { 
            IsOn = _isOn;
            IsMakingCoffee = _isMakingCoffee;
            WaterLevelState = _waterLevelState;
            BeanFeedState = _beanFeedState;
            WasteCoffeeState = _wasteCoffeeState;
            WaterTrayState = _waterTryState;
        }
        //public DateOnly Date { get; set; }
        //public int TemperatureC { get; set; }
        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        //public string? Summary { get; set; }
        public bool IsOn { get; }
        public bool IsMakingCoffee { get; }
        public State WaterLevelState { get; }
        public State BeanFeedState { get; }
        public State WasteCoffeeState { get; }
        public State WaterTrayState { get; }
        //Task TurnOnAsync();
        //Task TurnOffAsync();
        //Task MakeCoffeeAsync(CoffeeCreationOptions options);


        //public interface ICoffeeMachine
        //{
        //    bool IsOn { get; }
        //    bool IsMakingCoffee { get; }
        //    State WaterLevelState { get; }
        //    State BeanFeedState { get; }
        //    State WasteCoffeeState { get; }
        //    State WaterTrayState { get; }
        //    Task TurnOnAsync();
        //    Task TurnOffAsync();
        //    Task MakeCoffeeAsync(CoffeeCreationOptions options);
        //}

        public enum State
        {
            Okay = 0,
            Alert = 1
        }
    }
}