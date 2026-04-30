namespace Task1
{
    public class TabletFactory : ElectronicDeviceFactory
    {
        public override IElectronicDevice CreateDevice() => new Tablet();
    }
}
