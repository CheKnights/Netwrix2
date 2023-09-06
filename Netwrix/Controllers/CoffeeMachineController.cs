using Microsoft.AspNetCore.Mvc;

namespace Netwrix.Controllers
{
    //public class CoffeeMachineController : Controller
    [ApiController]
    [Route("[controller]")]
    public class CoffeeMachineController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        public struct CoffeeCreationOptions
        {
            public int NumEspressoShots { get; set; }
            public bool AddMilk { get; set; }
        }
        public class CoffeeMachineStub : CoffeeMachine.ICoffeeMachine
        {
            //void CoffeeMachine(bool _isOn, bool _IsMakingCoffee, CoffeeMachine.State _WaterLevelState, CoffeeMachine.State _BeenFeedState, CoffeeMachine.State _WasteCoffeeState, CoffeeMachine.State _WaterTrayState)
            //{
            //    IsOn = _isOn;
            //    IsMakingCoffee = _IsMakingCoffee;
            //    WaterLevelState = _WaterLevelState;
            //    BeanFeedState = _BeenFeedState;
            //    WasteCoffeeState = _WasteCoffeeState;
            //    WaterTrayState = _WaterTrayState;
            //}

            public bool IsOn { get; private set; }
            public bool IsMakingCoffee { get; private set; }
            public CoffeeMachine.State WaterLevelState { get; private set; }
            public CoffeeMachine.State BeanFeedState { get; private set; }
            public CoffeeMachine.State WasteCoffeeState { get; private set; }
            public CoffeeMachine.State WaterTrayState { get; private set; }
            //public Task TurnOnAsync();
            //public Task TurnOffAsync();
            //public Task MakeCoffeeAsync(CoffeeCreationOptions options);


            //public bool IsOn { get; private set; }
            //public bool IsMakingCoffee { get; private set; }
            //public State WaterLevelState { get; private set; }
            //public State BeanFeedState { get; private set; }
            //public State WasteCoffeeState { get; private set; }
            //public State WaterTrayState { get; private set; }
            private bool IsInAlertState => WaterLevelState == CoffeeMachine.State.Alert
            || BeanFeedState == CoffeeMachine.State.Alert
            || WasteCoffeeState == CoffeeMachine.State.Alert
            || WaterTrayState == CoffeeMachine.State.Alert;
            private readonly Random _randomStateGenerator;
            public CoffeeMachineStub()
            {
                _randomStateGenerator = new Random();
            }
            public async Task TurnOnAsync()
            {
                if (IsOn)
                    throw new InvalidOperationException("Invalid state");
                // Generate sample state for testing
                WaterLevelState = GetRandomState();
                BeanFeedState = GetRandomState();
                WasteCoffeeState = GetRandomState();
                WaterTrayState = GetRandomState();

                // [Machine turned on]
                IsOn = true;
            }
            public async Task TurnOffAsync()
            {
                if (!IsOn || IsMakingCoffee)
                    throw new InvalidOperationException("Invalid state");
                // [Machine turned off]
                IsOn = false;
            }
            public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
            {
                if (!IsOn || IsMakingCoffee || IsInAlertState)
                    throw new InvalidOperationException("Invalid state");
                IsMakingCoffee = true;
                // [Make the coffee]
                Thread.Sleep(10000);
                IsMakingCoffee = false;
            }
            // Randomly create a state for testing. This can be replaced as required.
            private CoffeeMachine.State GetRandomState() => _randomStateGenerator.Next(1, 10) == 10 ? CoffeeMachine.State.Alert : CoffeeMachine.State.Okay;


            //  public IEnumerable<CoffeeMachine> Get()
            [HttpGet(Name = "GetCoffeeMachineStatus")]
            public IEnumerable<CoffeeMachine> Get()
            {
                return Enumerable.Range(1, 1).Select(index => new CoffeeMachine
                    (true, true, CoffeeMachine.State.Okay, CoffeeMachine.State.Okay, CoffeeMachine.State.Okay, CoffeeMachine.State.Okay)
                ).ToArray();
                //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                //    TemperatureC = Random.Shared.Next(-20, 55),
                //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                //})
                //.ToArray();
            }
        }
    }
}


//YOU'RE TRYING TO FIGURE OUT HOW TO ADD A MODEL TO MOVE THE CODE IN THIS FILE 