using System;

class Number
{
    public static int PrintLastDigit(int number)
    {
        int lastd = number % 10;
        return lastd;
    }
}