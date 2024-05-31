/*
int[] array = new int[5];

array[0] = 100;
array[1] = 101;
array[2] = 102;
array[3] = 103;
array[4] = 104;

Console.WriteLine(array[0]);
*/

/*
int[] array = new int[5]
{
    100,101,102,103,104
};
Console.WriteLine(array[1]);
*/

/*
int[] array = new int[]
{
    100,101,102
};

Console.WriteLine(array[5]);
Console.WriteLine(array.Length);
*/

/*
int[] array = {
    100,101,102
};
Console.WriteLine(array[0]);
*/

/*
int[] array = {
    100,101,'ə'
};

Console.WriteLine(array[2]);
*/

/*
short num = 777;
double money = 16.7;
string numStr = "456";
int[] array = {
    num, (int)money, Convert.ToInt32(numStr)
};
Console.WriteLine(array);
*/

/*
char[] word = { 'T', 'e', 's', 't' };
Console.WriteLine(word);
*/

/*
decimal[] array = {
    1.1m,1.2m,1.3m
};

for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]}\t");
}
Console.WriteLine();
foreach (var item in array)
{
    Console.Write($"{item}\t");
}
*/


// в программе создан integer массив с размером N

// необходимо дать возможность пользователю
// ввести все значения массива

// вывести получившийся массив слудующим образом:
// "array: [1,2,3]"

/*
int length = 3;
int[] nums = new int[length];

Console.WriteLine($"Please fill all arrays' elements. Length = {length}\n");

for (int i = 0; i < length; i++)
{
    Console.Write($"Input {i + 1} element: ");
    nums[i] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine();
Console.Write("array: [");
for (int i = 0; i < length; i++)
{
    var numOutput = i == length - 1
        ? $"{nums[i]}"
        : $"{nums[i]},";

    Console.Write(numOutput);
}
Console.Write("]");
*/

/*
string text = "Hello World!";
Console.WriteLine(text[7]);
//text[5] = 'w';
*/

/*
int[] nums =
{
    1,22,333,4444
};

Console.WriteLine(nums.GetLength(0));
*/

/*
int[,] array = new int[3, 2]
{
    { 1, 2 },
    { 3, 4 },
    { 5, 6 },
};

Console.WriteLine(array[3, 1]);
*/