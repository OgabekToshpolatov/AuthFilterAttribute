namespace auten.Calculate;

public static class Calculate
{
    public static int Result(int a, int b)
    {
        int c=0;
            for(int i=1;i<=a;i++)
            {
                var list = i.ToString(); var k = list.Count();
                for(int j=0;j<k;j++)
                {
                    if(list[j].ToString()==b.ToString())  { c++; }
                }
            } return c ;
    }
}