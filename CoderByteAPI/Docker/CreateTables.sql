﻿USE [master]
GO

/****** Object:  Database [CoderByte]    Script Date: 22/11/2021 18:07:26 ******/
CREATE DATABASE [CoderByte]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoderByte', FILENAME = N'/var/opt/mssql/data/CoderByte.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoderByte_log', FILENAME = N'/var/opt/mssql/data/CoderByte_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoderByte].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CoderByte] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CoderByte] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CoderByte] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CoderByte] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CoderByte] SET ARITHABORT OFF 
GO

ALTER DATABASE [CoderByte] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CoderByte] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CoderByte] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CoderByte] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CoderByte] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CoderByte] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CoderByte] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CoderByte] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CoderByte] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CoderByte] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CoderByte] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CoderByte] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CoderByte] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CoderByte] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CoderByte] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CoderByte] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CoderByte] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CoderByte] SET RECOVERY FULL 
GO

ALTER DATABASE [CoderByte] SET  MULTI_USER 
GO

ALTER DATABASE [CoderByte] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CoderByte] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CoderByte] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [CoderByte] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [CoderByte] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [CoderByte] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [CoderByte] SET QUERY_STORE = OFF
GO

ALTER DATABASE [CoderByte] SET  READ_WRITE 
GO



/*Tables*/
CREATE TABLE Users(
	IdUser int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name varchar(max),
	Email varchar(max),
	DateOfBirth varchar(max),
	Phone varchar(max),
);

CREATE TABLE Address(
	IdAddress int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdUser int NOT NULL,
	Cep varchar(max) NOT NULL,
	Logradouro varchar(max),
	Complemento varchar(max),
	Bairro varchar(max),
	Localidade varchar(max),
	Uf varchar(max),
	Ibge varchar(max),
	Gia varchar(max),
	Ddd varchar(max),
	Siafi varchar(max),
	Categoria varchar(max),
	CONSTRAINT FK_Address_Users FOREIGN KEY (IdUser) REFERENCES Users(IdUser)
);

