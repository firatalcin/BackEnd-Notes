using _3_LiskovSubstitution;

//Miras veren classların özelliklerinin tamamı miras verdiği classlarda da çalışmalı

IPhone phone = new IPhone();
phone.Call();
phone.TakePhoto();

Nokia3310 phone2 = new Nokia3310();
phone2.Call();

