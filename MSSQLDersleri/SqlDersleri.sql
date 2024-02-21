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




