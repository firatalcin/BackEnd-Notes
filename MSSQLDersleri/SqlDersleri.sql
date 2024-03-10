Use Northwind

--Select Komutu

Select 3
select 'F�rat'
select 3,5,7
select 'F�rat', 'Al��n', 25
select * from Personeller
select Adi, SoyAdi from Personeller

--Alias Atama

Select 3 as De�er
Select Adi as �simler, SoyAdi as Soyisimler from Personeller

-- Bo�luk Karakteri Olan Sorgular

select * from [Satis Detaylari]

-- Kolonlar� Birle�tirme

select Adi + ' ' + SoyAdi [Personel Bilgileri] from Personeller

-- Farkl� Tipte Kolonlar� Birle�tirme

select Adi + ' ' + CONVERT(nvarchar,IseBaslamaTarihi) from Personeller
select Adi + ' ' + CAST(IseBaslamaTarihi as nvarchar) from Personeller

-- Personeller tablosunda �ehri London olan verileri listele

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

-- String Metotlar�

select LEFT(Adi,2) from Personeller
select RIGHT(Adi,2) from Personeller
select UPPER(Adi) from Personeller
select Lower(Adi) from Personeller
select SUBSTRING(Adi,3,2) from Personeller
select LTRIM('       F�rat')
select RTRIM('F�rat       ')
select REVERSE(Adi) from Personeller
select REPLACE('Benim Ad�m F�rat', 'F�rat', 'R�fat')
select MusteriAdi, CHARINDEX(' ', MusteriAdi) from Musteriler

-- Say�sal ��lemler

select PI()
select POWER(2,3)
select ABS(-100)
select RAND()
select FLOOR(RAND()*100)

-- Tarih Fonksiyonlar�

Select GETDATE() -- Bu g�n�n tarihini verir
select DATEADD(DAY,999,GETDATE()) -- belirli bir tarihten sonras�
select DATEDIFF(YEAR, '19980416', GETDATE()) -- iki tarih aras�ndaki fark�
select DATEPART(DAY,GETDATE())

-- Top Komutu

select top 3 * from Personeller

-- Distinct Komutu

select Distinct Sehir from Personeller

-- Group By Komutu

select KategoriID, COUNT(*) as 'Miktar' from Urunler where KategoriID > 5 group by KategoriID  
select PersonelID, Sum(NakliyeUcreti) from Satislar Group By PersonelID having Sum(NakliyeUcreti) > 5000

-- Tablolar� Yan yana birle�tirme

select * from Personeller
select * from Satislar
select * from Personeller,Satislar

-- Inner Join

select * from Personeller as p
inner join Satislar as s on p.PersonelID = s.PersonelID

-- �oklu Join

select * from Urunler as u
inner join Tedarikciler as t on u.TedarikciID = t.TedarikciID
inner join Kategoriler as k on u.KategoriID = k.KategoriID

--DML Sorgular�
-- Select

select * from Personeller

--Insert

Insert Personeller (Adi) values ('F�rat')

--Update 

update Personeller set Adi = 'R�fat' where PersonelID = 1

--Delete

Delete Personeller where PersonelID = 1

--Union
select Adi, SoyAdi from Personeller
union
select MusteriAdi, MusteriUnvani from Musteriler

-- With Rollup (Ara Toplam)
select SatisID, UrunID, SUM(Miktar) from [Satis Detaylari]
Group By SatisID, UrunID With Rollup



