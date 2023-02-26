namespace project.services.Impl;

public class RequestCounterService : ICounterService
{
  private int _counter;
  public int CounterValue { get => _counter; }
  public void Increase()
  {
    _counter++;
  }
}