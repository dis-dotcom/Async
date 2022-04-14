using System;

Main();

void Main()
{

}

void TestOne()
{
    Outer();
}

void TestTwo()
{
    Outer();
}

void Outer(Action action)
{
    action();
}
