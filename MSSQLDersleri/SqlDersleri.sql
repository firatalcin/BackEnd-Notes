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