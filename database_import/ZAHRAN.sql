/*
 Navicat Premium Data Transfer

 Source Server         : con-oracle
 Source Server Type    : Oracle
 Source Server Version : 210000 (Oracle Database 21c Express Edition Release 21.0.0.0.0 - Production)
 Source Host           : localhost:1521
 Source Schema         : ZAHRAN

 Target Server Type    : Oracle
 Target Server Version : 210000 (Oracle Database 21c Express Edition Release 21.0.0.0.0 - Production)
 File Encoding         : 65001

 Date: 17/08/2025 17:20:08
*/


-- ----------------------------
-- Table structure for DETAIL_TRANSAKSI
-- ----------------------------
DROP TABLE "ZAHRAN"."DETAIL_TRANSAKSI";
CREATE TABLE "ZAHRAN"."DETAIL_TRANSAKSI" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_76278".nextval NOT NULL,
  "JUMLAH_BARANG" NUMBER VISIBLE,
  "TOTAL" NUMBER VISIBLE,
  "ID_PRODUK" NUMBER VISIBLE,
  "ID_TRANSAKSI" NUMBER VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of DETAIL_TRANSAKSI
-- ----------------------------
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('41', '13', '416000', '8', '3');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('42', '5', '5000', '3', '3');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('1', '1', '80000', '9', '1');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('2', '4', '3600', '7', '2');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('44', '4', '47996', '2', '3');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('56', '11', '352000', '8', '25');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('57', '5', '5000', '3', '25');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('58', '7', '63000', '7', '25');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('81', '3', '96000', '8', '41');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('46', '5', '5000', '3', '21');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('47', '4', '128000', '8', '21');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('45', '9', '720000', '9', '21');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('60', '4', '320000', '9', '25');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('64', '1', '11999', '2', '27');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('62', '3', '35997', '2', '25');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('63', '1', '1000', '3', '26');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('65', '1', '32000', '8', '28');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('66', '1', '9000', '7', '29');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('48', '3', '240000', '9', '22');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('49', '5', '160000', '8', '23');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('51', '6', '54000', '7', '23');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('52', '6', '90000', '4', '23');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('53', '3', '240000', '9', '23');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('54', '4', '47996', '2', '24');
INSERT INTO "ZAHRAN"."DETAIL_TRANSAKSI" VALUES ('55', '4', '320000', '9', '24');

-- ----------------------------
-- Table structure for DOKUMEN_REQUEST
-- ----------------------------
DROP TABLE "ZAHRAN"."DOKUMEN_REQUEST";
CREATE TABLE "ZAHRAN"."DOKUMEN_REQUEST" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_75789".nextval NOT NULL,
  "NAMA_DOKUMEN" VARCHAR2(100 BYTE) VISIBLE,
  "DOKUMEN" VARCHAR2(1000 BYTE) VISIBLE,
  "USER_ID" NUMBER VISIBLE,
  "TOTAL_DOKUMEN" NUMBER VISIBLE,
  "STATUS" VARCHAR2(255 BYTE) VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of DOKUMEN_REQUEST
-- ----------------------------
INSERT INTO "ZAHRAN"."DOKUMEN_REQUEST" VALUES ('1', 'kemlu', NULL, '2', '0', 'Diajukan');
INSERT INTO "ZAHRAN"."DOKUMEN_REQUEST" VALUES ('2', 'kemlu', NULL, '2', '0', 'Diajukan');
INSERT INTO "ZAHRAN"."DOKUMEN_REQUEST" VALUES ('3', 'kemlu', 'b2bbcf03-ac0b-4bad-bd89-47821018bba6_Screenshot (3).png,e1896c85-5839-4bc4-8b5e-6b314259a7ae_Screenshot (4).png,81211b92-c521-4bd3-b997-b3271321e4ca_Screenshot (6).png', '2', '3', 'Diajukan');

-- ----------------------------
-- Table structure for IMPORTDATA
-- ----------------------------
DROP TABLE "ZAHRAN"."IMPORTDATA";
CREATE TABLE "ZAHRAN"."IMPORTDATA" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_77063".nextval NOT NULL,
  "KD_SATKER" NUMBER VISIBLE,
  "KD_COA" VARCHAR2(100 BYTE) VISIBLE,
  "PAGU" VARCHAR2(100 BYTE) VISIBLE,
  "REALISASI" VARCHAR2(100 BYTE) VISIBLE,
  "SISA_PAGU" VARCHAR2(100 BYTE) VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of IMPORTDATA
-- ----------------------------

-- ----------------------------
-- Table structure for PRODUK
-- ----------------------------
DROP TABLE "ZAHRAN"."PRODUK";
CREATE TABLE "ZAHRAN"."PRODUK" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_76114".nextval NOT NULL,
  "NAMA" VARCHAR2(100 BYTE) VISIBLE,
  "DESKRIPSI" CLOB VISIBLE,
  "GAMBAR_PRODUK" VARCHAR2(250 BYTE) VISIBLE,
  "HARGA" NUMBER VISIBLE,
  "STOK" NUMBER VISIBLE,
  "IS_DELETE" NUMBER VISIBLE DEFAULT 1,
  "ID_USERCOFFE" NUMBER VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of PRODUK
-- ----------------------------
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('8', 'Liberika', 'Kopi liberika (Coffea liberica) adalah jenis kopi yang memiliki ciri khas berupa ukuran biji yang lebih besar dan aroma unik yang mirip dengan buah nangka. Kopi ini dikenal tahan terhadap penyakit karat daun kopi, sehingga sering dijadikan alternatif saat penyakit tersebut menyerang tanaman kopi arabika. ', '/gambarProduks/f4ddfe84-fd94-4508-90e9-e9e16e062185.jpg', '32000', '8742', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('9', 'Cappucino', 'Cappuccino adalah minuman kopi klasik yang berasal dari Italia, terdiri dari espresso, susu yang dikukus, dan busa susu. Minuman ini biasanya memiliki komposisi yang seimbang antara espresso, susu kukus, dan busa susu. Rasa cappuccino dikenal lembut, halus, dan seimbang, dengan busa susu yang memberikan tekstur yang unik.', '/gambarProduks/41d353f2-7b33-41b1-a864-d3330e54fb39.jpg', '80000', '89755', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('27', 'Nabati', 'Nabti ada lorem', '/gambarProduks/a5a94a21-12df-4725-b535-fdb3bc15d91d.PNG', '20000', '9008', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('26', 'Kopi Macha', 'Matcha adalah teh hijau bubuk yang dibuat dengan menggiling daun teh hijau secara halus hingga menjadi bubuk halus', 'null', '13000', '87635', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('2', 'Kopi Arabika', 'Kopi arabika (Coffea arabica) adalah jenis kopi yang paling banyak dibudidayakan dan dikonsumsi di dunia, dikenal dengan cita rasa yang halus, kompleks, dan sedikit asam. Pohon kopi arabika tumbuh di ketinggian yang lebih tinggi, sekitar 600 hingga 2.000 meter di atas permukaan laut, dan membutuhkan suhu optimal antara 15 hingga 24 derajat Celcius. Kopi ini memiliki kandungan asam yang lebih tinggi dan aroma yang lebih kaya dibandingkan jenis kopi lainnya. 
Ciri-ciri Kopi Arabika:
Citarasa: Halus, kompleks, dan sedikit asam dengan aroma yang kaya. 
Karakteristik: Memiliki rasa manis dan ringan dengan aftertaste yang bisa manis atau beraroma buah. 
Kandungan: Memiliki kandungan kafein yang lebih rendah dibandingkan kopi robusta. 
Daerah Tumbuh: Tumbuh subur di dataran tinggi, antara 600 hingga 2.000 meter di atas permukaan laut. 
Rendemen: Biji arabika memiliki rendemen yang lebih tinggi dibandingkan robusta, sehingga menghasilkan lebih banyak kopi per kilogram biji. 
Ukurannya: Biji arabika berukuran lebih besar dibandingkan robusta. 
Perbedaan dengan Kopi Robusta:
Citarasa:
Arabika lebih halus dan beraroma kompleks, sementara robusta lebih kuat dan pahit. 
Kandungan Kafein:
Arabika memiliki kandungan kafein lebih rendah dibandingkan robusta. 
Rasa:
Arabika terasa manis dan ringan, sementara robusta terasa lebih kuat dan pahit. 
Daerah Tumbuh:
Arabika tumbuh di dataran tinggi, sementara robusta tumbuh di dataran rendah. 
Maaf, terjadi error.
KEISTIMEWAAN KOPI ARABIKA, KARAKTER & POHON KOPI
Biji kopi Arabika umumnya ditanam di ketinggian antara 600 hingga 2.000 meter di atas permukaan laut, di mana suhu optimal berada ...

Otten Coffee

pengenalan varietas unggul kopi
Warna daun : Daun muda sering mosaik, warna pupus daun hijau kecokelatan, daun tua berwarna hijau biasa. Bentuk daun : Permukaan d...

Repository Pertanian

Kopi arabika | Terakreditasi | Universitas STEKOM Semarang
L. Kopi arabika (Coffea arabica), juga dikenal sebagai kopi arab, kopi semak arab, atau kopi gunung, adalah spesies dari genus Cof...

P2K Stekom

Tampilkan semua
', '/gambarProduks/00f6dd43-0b29-4fed-bea2-3bab5a3eab22.jpg', '11999', '675', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('25', 'Kopi Tubruk', 'opi tubruk adalah metode penyajian kopi tradisional Indonesia yang sederhana, di mana bubuk kopi langsung diseduh dengan air panas di dalam gelas atau wadah tanpa menggunakan filter', 'null', '100000', '400', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('3', 'Robusta', 'Kopi robusta, dengan nama ilmiah Coffea canephora, dikenal dengan rasa kuat dan pahit, serta kadar kafein yang lebih tinggi dibandingkan kopi arabika. Kopi ini memiliki aroma yang khas, cenderung beraroma kacang-kacangan, dan sering digunakan dalam campuran espresso untuk menambah kekuatan rasa. ', '/gambarProduks/47abfd24-004e-4214-96c5-5320787fb10a.jpg', '1000', '9860', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('4', 'Bubuk Kopi', 'Kopi bubuk adalah biji kopi yang telah digiling atau dihancurkan menjadi serbuk halus. Proses ini memungkinkan kopi untuk diseduh dengan air panas dan menjadi minuman kopi. Kopi bubuk adalah bahan dasar untuk membuat kopi seduh, baik dengan cara tradisional maupun dengan menggunakan mesin kopi. ', '/gambarProduks/06746f00-103d-4001-b684-ce30bdb0bf5d.jpg', '15000', '963', '1', '2');
INSERT INTO "ZAHRAN"."PRODUK" VALUES ('7', 'Kopi Americano', 'Kopi Americano adalah minuman kopi yang dibuat dengan mencampurkan espresso dengan air panas. Minuman ini memiliki rasa yang lebih ringan dibandingkan espresso murni karena air panas melarutkan intensitas rasa pahit espresso. Americano disajikan tanpa tambahan gula atau krimer, dan seringkali diminum hangat atau dingin. ', '/gambarProduks/4cf32366-5844-474b-8561-04f1432343c9.jpg', '9000', '72', '1', '2');

-- ----------------------------
-- Table structure for SUPPLIER
-- ----------------------------
DROP TABLE "ZAHRAN"."SUPPLIER";
CREATE TABLE "ZAHRAN"."SUPPLIER" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_77369".nextval NOT NULL,
  "NAMA" VARCHAR2(100 BYTE) VISIBLE,
  "EMAIL" VARCHAR2(100 BYTE) VISIBLE,
  "ALAMAT" VARCHAR2(255 BYTE) VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of SUPPLIER
-- ----------------------------

-- ----------------------------
-- Table structure for TRANSAKSI
-- ----------------------------
DROP TABLE "ZAHRAN"."TRANSAKSI";
CREATE TABLE "ZAHRAN"."TRANSAKSI" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_76275".nextval NOT NULL,
  "TANGGAL" DATE VISIBLE,
  "NOMINAL" NUMBER VISIBLE,
  "ID_USERCOFFE" NUMBER VISIBLE,
  "METODE_PEMBAYARAN" VARCHAR2(255 BYTE) VISIBLE,
  "STATUS" VARCHAR2(255 BYTE) VISIBLE,
  "JUMLAH_BAYAR" NUMBER VISIBLE,
  "TANGGAL_SAMPAI" DATE VISIBLE DEFAULT NULL
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of TRANSAKSI
-- ----------------------------
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('1', TO_DATE('2025-05-16 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '130000', '2', 'COD', 'Sedang Dalam Perjalanan', '0', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('2', TO_DATE('2025-05-16 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '98000', '2', 'COD', 'Sedang Dalam Perjalanan', '0', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('3', TO_DATE('2025-05-16 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '459000', '2', 'COD', 'Sedang Dalam Perjalanan', '0', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('25', TO_DATE('2025-05-20 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '775997', '2', 'SALDO', 'Sedang Dalam Perjalanan', '775997', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('41', TO_DATE('2025-08-17 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '96000', '2', 'COD', 'Sedang Dalam Perjalanan', NULL, NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('21', TO_DATE('2025-05-19 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '570090', '2', 'COD', 'Sedang Dalam Perjalanan', '0', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('26', TO_DATE('2025-05-23 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '1000', '2', 'SALDO', 'Sedang Dalam Perjalanan', '1000', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('27', TO_DATE('2025-05-23 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '11999', '2', 'SALDO', 'Sedang Dalam Perjalanan', '11999', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('28', TO_DATE('2025-05-23 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '32000', '2', 'COD', 'Sedang Dalam Perjalanan', NULL, NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('29', TO_DATE('2025-05-23 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '9000', '2', 'SALDO', 'Sedang Dalam Perjalanan', '9000', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('22', TO_DATE('2025-05-19 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '240000', '2', 'COD', 'Sudah Sampai', '250000', TO_DATE('2025-05-23 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'));
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('23', TO_DATE('2025-05-19 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '544000', '2', 'COD', 'Selesai', '1000000', NULL);
INSERT INTO "ZAHRAN"."TRANSAKSI" VALUES ('24', TO_DATE('2025-05-19 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), '367996', '2', 'COD', 'Selesai', '1000000', NULL);

-- ----------------------------
-- Table structure for USERCOFFEE
-- ----------------------------
DROP TABLE "ZAHRAN"."USERCOFFEE";
CREATE TABLE "ZAHRAN"."USERCOFFEE" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_76119".nextval NOT NULL,
  "NAMA" VARCHAR2(100 BYTE) VISIBLE,
  "EMAIL" VARCHAR2(100 BYTE) VISIBLE,
  "TGL_LAHIR" DATE VISIBLE,
  "ALAMAT" CLOB VISIBLE,
  "PASSWORD" VARCHAR2(500 BYTE) VISIBLE,
  "IS_DELETE" NUMBER VISIBLE,
  "ROLE" VARCHAR2(255 BYTE) VISIBLE,
  "NO_HP" VARCHAR2(255 BYTE) VISIBLE,
  "SALDO" NUMBER VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of USERCOFFEE
-- ----------------------------
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('21', 'Didin Sahidin', 'didin@gmail.com', TO_DATE('2000-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Melati No. 45 RT 003/RW 007, Kel. Kebayoran Lama Utara, Kec. Kebayoran Lama, Kota Jakarta Selatan, DKI Jakarta 12240', '$2a$11$f4S8mcPfUCPA4yXnSlqV4O7jVm4ULVxtozzmMMzmVbaWJONFWkIOW', '0', 'user', '0873827367', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('22', 'Didin Sahidin', 'jojo@gmail.com', TO_DATE('2000-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Cihampelas No. 120 RT 005/RW 006, Kel. Cipaganti, Kec. Coblong, Kota Bandung, Jawa Barat 40131

', '$2a$11$vGFTyrTWcZgpS4o8g.DvcOHiR5O1RJRqcRIUgEi/yCD3YAphWvqD.', '0', 'user', '08736437584738', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('23', 'Didin Sahidin', 'sisil@gmail.com', TO_DATE('2000-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Terusan Pasirkoja No. 27 RT 004/RW 007, Kel. Babakan Ciparay, Kec. Babakan Ciparay, Kota Bandung, Jawa Barat 40223

', '$2a$11$Mw/ygtSB7AefjLEgEyIt2e4M0H2Ql0GZr3lMUtma7JfCXV.xd.00u', '0', 'user', '087382738212', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('24', 'Zahran Muhammad', 'zahranmhhh@gmail.com', TO_DATE('2000-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Kaliurang KM 7, Gang Melati No. 3, RT 006/RW 002, Kel. Caturtunggal, Kec. Depok, Kab. Sleman, Daerah Istimewa Yogyakarta 55281

', '$2a$11$GmF9TjLh3TmRi.2/qR1C1OcE5Mhob5CSBBjmZct5jxXjpk.rQ87ZS', '0', 'user', '087384756378', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('25', 'Sidiq Sodikin', 'sidiq@gmail.com', TO_DATE('2008-12-01 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl Kota Bandung Pasteur', '$2a$11$L63JJbqVuU1rY3J0/y16ZO25KhAhwXgfCE34KeOt/TZkQG4P/OguO', '0', 'deliver', '087766538', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('1', 'Zahran Muhammad Hisyam', 'zahranhh@gmail.com', TO_DATE('2006-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Setia Budi No. 58 RT 003/RW 004, Kel. Tanjung Rejo, Kec. Medan Sunggal, Kota Medan, Sumatera Utara 20122

', '$2a$11$skhMRuGLXCJN0cZ9/d7u..qOAKOO0S1/l7pWOvBnBru8caos7OpBC', '1', 'admin', '0888977629', '0');
INSERT INTO "ZAHRAN"."USERCOFFEE" VALUES ('2', 'Jamaludin', 'jamal@gmail.com', TO_DATE('1998-12-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS'), 'Jl. Anggrek No. 10 RT 001/RW 002, Kel. Kemanggisan, Kec. Palmerah, Kota Jakarta Barat, DKI Jakarta 11480

', '$2a$11$5uSArjkbDJvzDgPOToWLi.pv4nhX/2m3v4/Y85dfQgIBCrO32m5Nu', '0', 'user', '087239284728', '99202004');

-- ----------------------------
-- Table structure for USERS
-- ----------------------------
DROP TABLE "ZAHRAN"."USERS";
CREATE TABLE "ZAHRAN"."USERS" (
  "ID" NUMBER VISIBLE DEFAULT "ZAHRAN"."ISEQ$$_75777".nextval NOT NULL,
  "NAMA" VARCHAR2(100 BYTE) VISIBLE,
  "EMAIL" VARCHAR2(100 BYTE) VISIBLE,
  "PASSWORD" VARCHAR2(255 BYTE) VISIBLE,
  "IMG_PF" VARCHAR2(255 BYTE) VISIBLE,
  "KTP" VARCHAR2(255 BYTE) VISIBLE,
  "SALDO" NUMBER VISIBLE
)
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Records of USERS
-- ----------------------------
INSERT INTO "ZAHRAN"."USERS" VALUES ('21', 'koko', 'koko@gmail.com', '$2a$11$6HIvol65wk2r2Abw4r.cAuG.LPZGxcrh20C5QXZ2dAImxzCeWTsO.', '/uploads/0bceb0bc-a534-45d8-b462-4a8d6bbf345a.png', '/uploads/23c81005-bdc7-403e-b030-e07f5b63bd63.png', '0');
INSERT INTO "ZAHRAN"."USERS" VALUES ('2', 'jamal', 'jamal@gmail.com', '$2a$11$lbZVQx84MMyW6e3D76cvL.bkqRSEB3JhvhDhLybBL9Gm4Anus.1.S', '/uploads/75bded1c-ec3f-4285-8f5a-22cddeaba061.png', '/uploads/0469c4e4-826e-4a06-8188-89fddafc7b97.png', '0');

-- ----------------------------
-- Sequence structure for ISEQ$$_75777
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_75777";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_75777" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_75789
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_75789";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_75789" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_76109
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_76109";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_76109" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_76114
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_76114";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_76114" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_76119
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_76119";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_76119" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_76275
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_76275";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_76275" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_76278
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_76278";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_76278" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_77063
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_77063";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_77063" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Sequence structure for ISEQ$$_77369
-- ----------------------------
DROP SEQUENCE "ZAHRAN"."ISEQ$$_77369";
CREATE SEQUENCE "ZAHRAN"."ISEQ$$_77369" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 CACHE 20;

-- ----------------------------
-- Primary Key structure for table DETAIL_TRANSAKSI
-- ----------------------------
ALTER TABLE "ZAHRAN"."DETAIL_TRANSAKSI" ADD CONSTRAINT "SYS_C008233" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table DETAIL_TRANSAKSI
-- ----------------------------
ALTER TABLE "ZAHRAN"."DETAIL_TRANSAKSI" ADD CONSTRAINT "SYS_C008232" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table DOKUMEN_REQUEST
-- ----------------------------
ALTER TABLE "ZAHRAN"."DOKUMEN_REQUEST" ADD CONSTRAINT "SYS_C008223" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table DOKUMEN_REQUEST
-- ----------------------------
ALTER TABLE "ZAHRAN"."DOKUMEN_REQUEST" ADD CONSTRAINT "SYS_C008222" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table IMPORTDATA
-- ----------------------------
ALTER TABLE "ZAHRAN"."IMPORTDATA" ADD CONSTRAINT "SYS_C008235" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table IMPORTDATA
-- ----------------------------
ALTER TABLE "ZAHRAN"."IMPORTDATA" ADD CONSTRAINT "SYS_C008234" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table PRODUK
-- ----------------------------
ALTER TABLE "ZAHRAN"."PRODUK" ADD CONSTRAINT "SYS_C008227" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table PRODUK
-- ----------------------------
ALTER TABLE "ZAHRAN"."PRODUK" ADD CONSTRAINT "SYS_C008226" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table SUPPLIER
-- ----------------------------
ALTER TABLE "ZAHRAN"."SUPPLIER" ADD CONSTRAINT "SYS_C008237" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table SUPPLIER
-- ----------------------------
ALTER TABLE "ZAHRAN"."SUPPLIER" ADD CONSTRAINT "SYS_C008236" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table TRANSAKSI
-- ----------------------------
ALTER TABLE "ZAHRAN"."TRANSAKSI" ADD CONSTRAINT "SYS_C008231" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table TRANSAKSI
-- ----------------------------
ALTER TABLE "ZAHRAN"."TRANSAKSI" ADD CONSTRAINT "SYS_C008230" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table USERCOFFEE
-- ----------------------------
ALTER TABLE "ZAHRAN"."USERCOFFEE" ADD CONSTRAINT "SYS_C008229" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table USERCOFFEE
-- ----------------------------
ALTER TABLE "ZAHRAN"."USERCOFFEE" ADD CONSTRAINT "SYS_C008228" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table USERS
-- ----------------------------
ALTER TABLE "ZAHRAN"."USERS" ADD CONSTRAINT "SYS_C008221" PRIMARY KEY ("ID");

-- ----------------------------
-- Checks structure for table USERS
-- ----------------------------
ALTER TABLE "ZAHRAN"."USERS" ADD CONSTRAINT "SYS_C008220" CHECK ("ID" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;
