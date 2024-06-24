-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 23 Jun 2024 pada 17.38
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_certainty`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `basis_pengetahuan`
--

CREATE TABLE `basis_pengetahuan` (
  `Kode_Basis` varchar(15) NOT NULL,
  `Kode_Penyakit` varchar(15) NOT NULL,
  `Kode_Gejala` varchar(15) NOT NULL,
  `Nilai_CF` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data untuk tabel `basis_pengetahuan`
--

INSERT INTO `basis_pengetahuan` (`Kode_Basis`, `Kode_Penyakit`, `Kode_Gejala`, `Nilai_CF`) VALUES
('KB001', 'P01', 'G1', 0.9),
('KB002', 'P01', 'G2', 0.9),
('KB003', 'P01', 'G3', 0.7),
('KB004', 'P01', 'G4', 0.8),
('KB005', 'P01', 'G5', 0.8),
('KB006', 'P01', 'G6', 0.6),
('KB007', 'P01', 'G7', 0.8),
('KB008', 'P01', 'G8', 0.6),
('KB009', 'P01', 'G9', 0.6);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_diagnosa`
--

CREATE TABLE `tabel_diagnosa` (
  `Nomor` varchar(11) NOT NULL,
  `Nama_Gejala` varchar(50) NOT NULL,
  `Nilai_Pakar` double NOT NULL,
  `Nilai_User` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_gejala`
--

CREATE TABLE `tabel_gejala` (
  `Kode_Gejala` varchar(15) NOT NULL,
  `Nama_Gejala` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data untuk tabel `tabel_gejala`
--

INSERT INTO `tabel_gejala` (`Kode_Gejala`, `Nama_Gejala`) VALUES
('G1', 'Sering Kencing Malam'),
('G2', 'Sesak Nafas'),
('G3', 'Sering Haus dan Lapar'),
('G4', 'Berat Badan Turun Drastis'),
('G5', 'Penglihatan Kabur'),
('G6', 'Meningkatnya Frekuensi Infeksi'),
('G7', 'Turunnya Kesadaran'),
('G8', 'Sering Kesemutan'),
('G9', 'Keturanan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_hasil_diagnosa`
--

CREATE TABLE `tabel_hasil_diagnosa` (
  `Kode_Pemeriksaan` varchar(15) NOT NULL,
  `Kode_Pasien` varchar(15) NOT NULL,
  `Nama_Pasien` varchar(60) NOT NULL,
  `Nomor_HP` varchar(15) NOT NULL,
  `Nama_Penyakit` varchar(100) NOT NULL,
  `Tingkat_Keyakinan` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_pasien`
--

CREATE TABLE `tabel_pasien` (
  `Kode_Pasien` varchar(15) NOT NULL,
  `Nama_Pasien` varchar(60) NOT NULL,
  `Alamat` varchar(80) NOT NULL,
  `Nomor_HP` varchar(20) NOT NULL,
  `Umur` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_penyakit`
--

CREATE TABLE `tabel_penyakit` (
  `Kode_Penyakit` varchar(15) NOT NULL,
  `Nama_Penyakit` varchar(50) NOT NULL,
  `Solusi` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data untuk tabel `tabel_penyakit`
--

INSERT INTO `tabel_penyakit` (`Kode_Penyakit`, `Nama_Penyakit`, `Solusi`) VALUES
('P01', 'Diabetes Melitus type I dan II', 'Cek Gula darah + Atur Ulang Pola Makan + Olahraga Rutin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tabel_user`
--

CREATE TABLE `tabel_user` (
  `Nama_User` varchar(50) NOT NULL,
  `Username` varchar(25) NOT NULL,
  `Password` varchar(15) NOT NULL,
  `Level` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data untuk tabel `tabel_user`
--

INSERT INTO `tabel_user` (`Nama_User`, `Username`, `Password`, `Level`) VALUES
('Sakinatun Nafsih', 'Pakar', '1234', 'Pakar'),
('Rinda Sabela', 'User', '4321', 'User');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `basis_pengetahuan`
--
ALTER TABLE `basis_pengetahuan`
  ADD PRIMARY KEY (`Kode_Basis`);

--
-- Indeks untuk tabel `tabel_diagnosa`
--
ALTER TABLE `tabel_diagnosa`
  ADD PRIMARY KEY (`Nomor`);

--
-- Indeks untuk tabel `tabel_gejala`
--
ALTER TABLE `tabel_gejala`
  ADD PRIMARY KEY (`Kode_Gejala`);

--
-- Indeks untuk tabel `tabel_hasil_diagnosa`
--
ALTER TABLE `tabel_hasil_diagnosa`
  ADD PRIMARY KEY (`Kode_Pemeriksaan`);

--
-- Indeks untuk tabel `tabel_pasien`
--
ALTER TABLE `tabel_pasien`
  ADD PRIMARY KEY (`Kode_Pasien`);

--
-- Indeks untuk tabel `tabel_penyakit`
--
ALTER TABLE `tabel_penyakit`
  ADD PRIMARY KEY (`Kode_Penyakit`);

--
-- Indeks untuk tabel `tabel_user`
--
ALTER TABLE `tabel_user`
  ADD PRIMARY KEY (`Username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
