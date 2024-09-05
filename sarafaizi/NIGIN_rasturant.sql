-- Veritabanını oluştur
CREATE DATABASE NIGIN_RETURANT;
GO

-- Veritabanını kullan
USE NIGIN_RETURANT;
GO



-- Personel girişi tablosunu oluştur
CREATE TABLE personel_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- Yönetici girişi tablosunu oluştur
CREATE TABLE yonetici_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- Örnek verileri personel_giris ve yonetici_giris tablolarına ekle
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('SARA','12345');
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('S','1');

INSERT INTO yonetici_giris (kullaniciad, sifre) VALUES ('A','1');
GO

-- Masalar tablosunu oluştur
CREATE TABLE MASALAR (
    masaid INT PRIMARY KEY IDENTITY(1,1),
    kapasite INT NOT NULL,
    durum NVARCHAR(4) NOT NULL CHECK (durum IN('boş','dolu')),
    rezervasyondurumu NVARCHAR(5) NOT NULL CHECK(rezervasyondurumu IN('evet','hayır'))
);
GO
insert into MASALAR values ('4','boş','evet');


CREATE TABLE MENU (
    urunid INT PRIMARY KEY IDENTITY(1,1),
    isim NVARCHAR(50) NOT NULL,
    fiyat int NOT NULL,
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatlılar', 'İçecekler', 'Ara Sıcaklar', 'Salatalar')),
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
4. Satış Formu
Siparişlerin ödeme işlemlerinin kaydı. 
 Ödeme Numarası: Her ödeme işlemine özgü bir numara.
 Masa Numarası: Ödemenin yapıldığı masa numarası, masalar formundan gelecek
 Ödeme Türü: Nakit, kredi kartı gibi ödeme türü.
 Toplam Tutar: Ödenen toplam tutar, sipariş formundan gelecek*/

create table SATIS(
    odemeid int primary key identity(1,1),
    masaid int,
    odemeturu nvarchar(50) check (odemeturu in ('nakit','kart','havale')),
    siparisid int,
	odencek_tutar int,
	FOREIGN KEY (masaid) REFERENCES MASALAR(masaid),
	FOREIGN KEY (siparisid) REFERENCES SIPARISLER(siparisid)
	);
	SELECT * FROM SATIS
	
	/*5. Z Raporu Formu
Günlük satış raporlarının oluşturulması. 
 Rapor Tarihi: Raporun oluşturulduğu tarih.
 Toplam Satış: Gün boyunca yapılan toplam satış tutarı, satış formundan hesaplanarak 
yapılmalıdır.
 İşlem Sayısı: Gerçekleştirilen toplam işlem sayısı, sipariş formundan alınacak. Sipariş 
numarası sayısından elde edilebilir.*/

SELECT SUM(odencek_tutar) from SATIS

SELECT COUNT(siparisid) FROM SIPARISLER

create table rapor(
raporid int primary key identity(1,1),
raportarihi nvarchar(50),
toplamsatıs int,
islemsayisi int,);
 
select * from rapor
/*
6. Stok Ekranı Formu
Restoranın stok yönetimi. 
 Ürün Kodu: Stoktaki her ürüne özgü bir kod.
 Ürün İsmi: Stoktaki ürünün ismi.
 Mevcut Miktar: Üründen kalan miktar.
 Minimum Stok Miktarı: Sipariş verilmesi gereken minimum miktar.
 Tedarikçi Bilgileri: Ürünü sağlayan tedarikçinin bilgileri.*/


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
























CREATE TABLE MENU (
    urunid INT PRIMARY KEY IDENTITY(1,1),
    isim NVARCHAR(50) NOT NULL,
    fiyat int NOT NULL,
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatlılar', 'İçecekler', 'Ara Sıcaklar', 'Salatalar')),
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