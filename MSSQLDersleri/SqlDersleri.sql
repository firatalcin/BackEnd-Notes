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