Use Northwind

--Select Komutu

Select 3
select 'Fýrat'
select 3,5,7
select 'Fýrat', 'Alçýn', 25
select * from Personeller
select Adi, SoyAdi from Personeller

--Alias Atama

Select 3 as Deðer
Select Adi as Ýsimler, SoyAdi as Soyisimler from Personeller

-- Boþluk Karakteri Olan Sorgular

select * from [Satis Detaylari]

-- Kolonlarý Birleþtirme

select Adi + ' ' + SoyAdi [Personel Bilgileri] from Personeller

-- Farklý Tipte Kolonlarý Birleþtirme

select Adi + ' ' + CONVERT(nvarchar,IseBaslamaTarihi) from Personeller
select Adi + ' ' + CAST(IseBaslamaTarihi as nvarchar) from Personeller

-- Personeller tablosunda þehri London olan verileri listele

select * from Personeller where Sehir = 'London'
select * from Personeller where Sehir = 'London' and Unvan = 'Sales Manager'

-- Between

select * from Personeller where YEAR(DogumTarihi) between 1950 and 1965

-- In

select * from Personeller where Sehir in ('London', 'Tocoma')

-- LIKE

select * from Personeller where Adi like 'j%'
select * from Personeller where Adi like '%y'
select * from Personeller where Adi like 'r%t'
select * from Personeller where Adi like '%an%'
select * from Personeller where Adi like 'a_d%'
select * from Personeller where Adi like '[nmr]%' -- ilk harfi m or n or r
select * from Personeller where Adi like '[^a]%'

-- Aggregate Fonksiyonlar

select AVG(PersonelID) from Personeller
select MAX(PersonelID) from Personeller
select Min(PersonelID) from Personeller
select COUNT(PersonelID) from Personeller
select sum(NakliyeUcreti) from Satislar

-- String Metotlarý

select LEFT(Adi,2) from Personeller
select RIGHT(Adi,2) from Personeller
select UPPER(Adi) from Personeller
select Lower(Adi) from Personeller
select SUBSTRING(Adi,3,2) from Personeller
select LTRIM('       Fýrat')
select RTRIM('Fýrat       ')
select REVERSE(Adi) from Personeller
select REPLACE('Benim Adým Fýrat', 'Fýrat', 'Rýfat')
select MusteriAdi, CHARINDEX(' ', MusteriAdi) from Musteriler

-- Sayýsal Ýþlemler

select PI()
select POWER(2,3)
select ABS(-100)
select RAND()
select FLOOR(RAND()*100)

-- Tarih Fonksiyonlarý

Select GETDATE() -- Bu günün tarihini verir
select DATEADD(DAY,999,GETDATE()) -- belirli bir tarihten sonrasý
select DATEDIFF(YEAR, '19980416', GETDATE()) -- iki tarih arasýndaki farký
select DATEPART(DAY,GETDATE())

-- Top Komutu

select top 3 * from Personeller

-- Distinct Komutu

select Distinct Sehir from Personeller

-- Group By Komutu

select KategoriID, COUNT(*) as 'Miktar' from Urunler where KategoriID > 5 group by KategoriID  
select PersonelID, Sum(NakliyeUcreti) from Satislar Group By PersonelID having Sum(NakliyeUcreti) > 5000

-- Tablolarý Yan yana birleþtirme

select * from Personeller
select * from Satislar
select * from Personeller,Satislar

-- Inner Join

select * from Personeller as p
inner join Satislar as s on p.PersonelID = s.PersonelID

-- Çoklu Join

select * from Urunler as u
inner join Tedarikciler as t on u.TedarikciID = t.TedarikciID
inner join Kategoriler as k on u.KategoriID = k.KategoriID

--DML Sorgularý
-- Select

select * from Personeller

--Insert

Insert Personeller (Adi) values ('Fýrat')

--Update 

update Personeller set Adi = 'Rýfat' where PersonelID = 1

--Delete

Delete Personeller where PersonelID = 1

--Union
select Adi, SoyAdi from Personeller
union
select MusteriAdi, MusteriUnvani from Musteriler

-- With Rollup (Ara Toplam)
select SatisID, UrunID, SUM(Miktar) from [Satis Detaylari]
Group By SatisID, UrunID With Rollup



