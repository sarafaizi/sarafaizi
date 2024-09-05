-- Veritabanýný oluþtur
CREATE DATABASE NIGIN_RETURANT;
GO

-- Veritabanýný kullan
USE NIGIN_RETURANT;
GO



-- Personel giriþi tablosunu oluþtur
CREATE TABLE personel_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- Yönetici giriþi tablosunu oluþtur
CREATE TABLE yonetici_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- Örnek verileri personel_giris ve yonetici_giris tablolarýna ekle
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('SARA','12345');
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('S','1');

INSERT INTO yonetici_giris (kullaniciad, sifre) VALUES ('A','1');
GO

-- Masalar tablosunu oluþtur
CREATE TABLE MASALAR (
    masaid INT PRIMARY KEY IDENTITY(1,1),
    kapasite INT NOT NULL,
    durum NVARCHAR(4) NOT NULL CHECK (durum IN('boþ','dolu')),
    rezervasyondurumu NVARCHAR(5) NOT NULL CHECK(rezervasyondurumu IN('evet','hayýr'))
);
GO
insert into MASALAR values ('4','boþ','evet');
select * from personel_giris
select * from personel_giris
select * from MASALAR


CREATE TABLE MENU (
    urunid INT PRIMARY KEY IDENTITY(1,1),
    isim NVARCHAR(50) NOT NULL,
    fiyat int NOT NULL,
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatlýlar', 'Ýçecekler', 'Ara Sýcaklar', 'Salatalar')),
    aciklama NVARCHAR(255)
);
GO

DROP TABLE MENU
select * from menu

create table SIPARISLER(
	siparisid int primary key identity(1,1),
	masaid int,
	sipariszamani datetime,
	urunid int,
	urunadet int,
	toplamtutar int,
	FOREIGN KEY (masaid) REFERENCES MASALAR(masaid),
	FOREIGN KEY (urunid) REFERENCES MENU(urunid));
	
	insert into SIPARISLER values (1,'24.05.2024','6',7,110);
	INSERT INTO SIPARISLER VALUES (1, '2024-05-26 14:30:00', 6, 2, 50);

	select * from SIPARISLER

ALTER TABLE SIPARISLER
ALTER COLUMN sipariszamani nvarchar(50);

DELETE FROM SIPARISLER WHERE sipariszamani = '2024-05-26';
ALTER TABLE SIPARISLER
ALTER COLUMN sipariszamani int;

/*
4. Satýþ Formu
Sipariþlerin ödeme iþlemlerinin kaydý. 
? Ödeme Numarasý: Her ödeme iþlemine özgü bir numara.
? Masa Numarasý: Ödemenin yapýldýðý masa numarasý, masalar formundan gelecek
? Ödeme Türü: Nakit, kredi kartý gibi ödeme türü.
? Toplam Tutar: Ödenen toplam tutar, sipariþ formundan gelecek*/

create table SATIS(
    odemeid int primary key identity(1,1),
    masaid int,
    odemeturu nvarchar(50) check (odemeturu in ('nakit','kart','havale')),
    siparisid int,
	odencek_tutar int,
	FOREIGN KEY (masaid) REFERENCES MASALAR(masaid),
	FOREIGN KEY (siparisid) REFERENCES SIPARISLER(siparisid)
	);

	/*5. Z Raporu Formu
Günlük satýþ raporlarýnýn oluþturulmasý. 
? Rapor Tarihi: Raporun oluþturulduðu tarih.
? Toplam Satýþ: Gün boyunca yapýlan toplam satýþ tutarý, satýþ formundan hesaplanarak 
yapýlmalýdýr.
? Ýþlem Sayýsý: Gerçekleþtirilen toplam iþlem sayýsý, sipariþ formundan alýnacak. Sipariþ 
numarasý sayýsýndan elde edilebilir.*/

SELECT SUM(odencek_tutar) from SATIS

SELECT COUNT(siparisid) FROM SIPARISLER

create table rapor(
raporid int primary key identity(1,1),
raportarihi nvarchar(50),
toplamsatýs int,
islemsayisi int,);
 
select * from rapor
/*
6. Stok Ekraný Formu
Restoranýn stok yönetimi. 
? Ürün Kodu: Stoktaki her ürüne özgü bir kod.
? Ürün Ýsmi: Stoktaki ürünün ismi.
? Mevcut Miktar: Üründen kalan miktar.
? Minimum Stok Miktarý: Sipariþ verilmesi gereken minimum miktar.
? Tedarikçi Bilgileri: Ürünü saðlayan tedarikçinin bilgileri.*/


CREATE TABLE STOK1(
stokid int primary key identity(1,1),
urunid int,
stokisim nvarchar(50),
stokmiktar int,
urunadet int,
kalanstokmiktari int,
minstokmiktar int,
tedarikci_bilgileri nvarchar(50),
FOREIGN KEY (urunid) REFERENCES MENU(urunid),

);
select * from  STOK1

CREATE TABLE STOK(
stokid int primary key identity(1,1),
stokisim nvarchar(50),
stokmiktar int,
minstokmiktar int,
tedarikci_bilgileri nvarchar(50)
);
select * from stok

ALTER TABLE STOK
ADD kalanstokmiktari int;



ALTER TABLE STOK
ADD urunid int;


ALTER TABLE STOK
add FOREIGN KEY (urunid) REFERENCES MENU(urunid);























CREATE TABLE MENU (
    urunid INT PRIMARY KEY IDENTITY(1,1),
    isim NVARCHAR(50) NOT NULL,
    fiyat int NOT NULL,
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatlýlar', 'Ýçecekler', 'Ara Sýcaklar', 'Salatalar')),
    aciklama NVARCHAR(255)
);
GO

DROP TABLE MENU
select * from menu





/*
CREATE TABLE SEHIR(
sehirid int primary key identity(1,1),
sehirisim nvarchar(50)
);

create table araba(
arabaid int primary key,
arabaad nvarchar(50),
sehirid int,
FOREIGN KEY (sehirid) REFERENCES SEHIR(sehirid));

insert into SEHIR values ('istanbul');
insert into araba(arabaid,arabaad,sehirid) values (5,'bm',1);
insert into araba(arabaid,arabaad,sehirid) values (4,'bm',2);
select * from SEHIR
select * from araba
*/