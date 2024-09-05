CREATE DATABASE NIGIN_RETURANT;
CREATE TABLE MASALAR(
masaid int primary key identity(1,1),
kapasite int not null,
durum nvarchar(4) not null check (durum in('boþ','dolu')),
rezervasyondurumu nvarchar(5) not null check(rezervasyondurumu in('evet','hayýr')),
);
create table personel_giris(
kullaniciid int primary key identity(1,1),
kullaniciad nvarchar(50) not null,
sifre nvarchar(50) not null);

create table yonetici_giris(
kullaniciid int primary key identity(1,1),
kullaniciad nvarchar(5) not null,
sifre nvarchar(50) not null);

insert into personel_giris values ('SARA','12345');
insert into yonetici_giris values ('ADMIN','12345');
SELECT * FROM personel_giris
SELECT * FROM yonetici_giris



CREATE TABLE MASALAR(
masaid int primary key identity(1,1),
kapasite int not null,
durum nvarchar(4) not null check (durum in('boþ','dolu')),
rezervasyondurumu nvarchar(5) not null check(rezervasyondurumu in('evet','hayýr')),
);

CREATE TABLE MENU(
urunid int primary key identity(1,1),
isim nvarchar(50) not null,
fiyat int(50),

