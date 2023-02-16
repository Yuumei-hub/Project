
namespace AbstractsLib
{
    public abstract class Device
    {
        public Device(string name, string make)
        {
            _name = name;
            _make = make;
        }
        protected string _name;
        protected string _make;
        public abstract void StartDevice();
        public abstract void StopDevice();
    }
}