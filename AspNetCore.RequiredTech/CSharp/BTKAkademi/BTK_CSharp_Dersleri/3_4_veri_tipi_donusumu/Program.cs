/*
   Veri Tipi Dönüşümü
   // implicit casting => bilinçsiz tür dönüşümü
   // explicit casting => bilinçli tür dönüşümü
*/

int a = 10;
long b = a;

long d = 20;
int e = (int)d;

double f = 20.5;
float g = (float)f;

double h = 10.5;
int i = (int)h;

Console.WriteLine(i);

int x = 10;
string z = x.ToString();
