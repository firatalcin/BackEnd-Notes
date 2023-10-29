//Bir uygulamanın gelişime açık ama değişime kapalı olmasıdır.
// Yeni kodlar eklenebilir ama eski kodlar bozulamaz


using _2_OpenClosed;

SalaryCalculate salaryCalculate = new SalaryCalculate();
Console.WriteLine(salaryCalculate.Calculate(2000,new LowSalaryCalculate()));
Console.WriteLine(salaryCalculate.Calculate(2000,new MiddleSalaryCalculate()));
Console.WriteLine(salaryCalculate.Calculate(2000,new HighSalaryCalculate()));
Console.WriteLine(salaryCalculate.Calculate(2000,new ManagerSalaryCalculate()));
