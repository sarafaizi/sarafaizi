-- Veritaban�n� olu�tur
CREATE DATABASE NIGIN_RETURANT;
GO

-- Veritaban�n� kullan
USE NIGIN_RETURANT;
GO



-- Personel giri�i tablosunu olu�tur
CREATE TABLE personel_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- Y�netici giri�i tablosunu olu�tur
CREATE TABLE yonetici_giris (
    kullaniciid INT PRIMARY KEY IDENTITY(1,1),
    kullaniciad NVARCHAR(50) NOT NULL,
    sifre NVARCHAR(50) NOT NULL
);
GO

-- �rnek verileri personel_giris ve yonetici_giris tablolar�na ekle
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('SARA','12345');
INSERT INTO personel_giris (kullaniciad, sifre) VALUES ('S','1');

INSERT INTO yonetici_giris (kullaniciad, sifre) VALUES ('A','1');
GO

-- Masalar tablosunu olu�tur
CREATE TABLE MASALAR (
    masaid INT PRIMARY KEY IDENTITY(1,1),
    kapasite INT NOT NULL,
    durum NVARCHAR(4) NOT NULL CHECK (durum IN('bo�','dolu')),
    rezervasyondurumu NVARCHAR(5) NOT NULL CHECK(rezervasyondurumu IN('evet','hay�r'))
);
GO
insert into MASALAR values ('4','bo�','evet');
select * from personel_giris
select * from personel_giris
select * from MASALAR


CREATE TABLE MENU (
    urunid INT PRIMARY KEY IDENTITY(1,1),
    isim NVARCHAR(50) NOT NULL,
    fiyat int NOT NULL,
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatl�lar', '��ecekler', 'Ara S�caklar', 'Salatalar')),
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
4. Sat�� Formu
Sipari�lerin �deme i�lemlerinin kayd�. 
? �deme Numaras�: Her �deme i�lemine �zg� bir numara.
? Masa Numaras�: �demenin yap�ld��� masa numaras�, masalar formundan gelecek
? �deme T�r�: Nakit, kredi kart� gibi �deme t�r�.
? Toplam Tutar: �denen toplam tutar, sipari� formundan gelecek*/

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
G�nl�k sat�� raporlar�n�n olu�turulmas�. 
? Rapor Tarihi: Raporun olu�turuldu�u tarih.
? Toplam Sat��: G�n boyunca yap�lan toplam sat�� tutar�, sat�� formundan hesaplanarak 
yap�lmal�d�r.
? ��lem Say�s�: Ger�ekle�tirilen toplam i�lem say�s�, sipari� formundan al�nacak. Sipari� 
numaras� say�s�ndan elde edilebilir.*/

SELECT SUM(odencek_tutar) from SATIS

SELECT COUNT(siparisid) FROM SIPARISLER

create table rapor(
raporid int primary key identity(1,1),
raportarihi nvarchar(50),
toplamsat�s int,
islemsayisi int,);
 
select * from rapor
/*
6. Stok Ekran� Formu
Restoran�n stok y�netimi. 
? �r�n Kodu: Stoktaki her �r�ne �zg� bir kod.
? �r�n �smi: Stoktaki �r�n�n ismi.
? Mevcut Miktar: �r�nden kalan miktar.
? Minimum Stok Miktar�: Sipari� verilmesi gereken minimum miktar.
? Tedarik�i Bilgileri: �r�n� sa�layan tedarik�inin bilgileri.*/


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
    kategori NVARCHAR(50) NOT NULL CHECK (kategori IN ('Ana Yemekler', 'Tatl�lar', '��ecekler', 'Ara S�caklar', 'Salatalar')),
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