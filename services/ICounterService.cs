namespace project.services;

public interface ICounterService
{
  int CounterValue { get; }
  void Increase();
}