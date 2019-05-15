/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4224)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[StokProcedure]    Script Date: 29.09.2018 19:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StokProcedure]
	  (@MalKodu varchar(30), @BasTarih int, @BitTarih int)
AS
BEGIN
	SET NOCOUNT ON;
  
	CREATE TABLE #BaseData
	( 
		  SiraNo int,
		  IslemTuru varchar(20),
		  EvrakNo varchar(16),
		  Tarih datetime,
		  GirisMiktar numeric(25,6),
		  CikisMiktar numeric(25,6),
		  StokMiktar numeric(25,6)
	) 
	Declare @siraNo int; -- Sýra Numarasý  artan þekilde yazdýrýlacak.  sýra numarasýný tablodaki id ile eþleþtirdim sýra numarasýndan kastýnýz galiba tablodaki id alanýydý
	Declare @islemTuru varchar(20);
	Declare @evrakNo varchar(16);
	Declare @tarih datetime; -- artan þekilde  yazdýrýlacak
	Declare @girisMiktar  numeric(25,6);
	Declare @cikisMiktar  numeric(25,6);
	Declare @stokMiktar numeric(25,6);
	Declare @toplam numeric(25,6);
	Declare @islem bit;

	   
    Declare cursor_stokMiktar CURSOR FOR
        SELECT 
		a.ID, 
		IIF(a.IslemTur = 0 , 'Giriþ', 'Çýkýþ') as IslemTuru, 
		a.EvrakNo as EvrakNo,  
		CONVERT(varchar(15),CAST(a.Tarih -2 as datetime), 101) as Tarih,
		IIF(a.IslemTur = 0, a.Miktar, 0) as GirisMiktar,
		IIF(a.IslemTur = 1, a.Miktar, 0) as CikisMiktar,
		a.IslemTur, a.Miktar 
        FROM dbo.STI a 
		where a.MalKodu = IIF(@MalKodu is null ,a.MalKodu, IIF(@MalKodu = '' , a.MalKodu , @MalKodu))  -- program ilk çalýþtýðýnda bir aralýk girilmeden tüm kayýtlarý çekmek için
		and a.Tarih between IIF(@BasTarih = 0, a.Tarih , @BasTarih) and IIF(@BitTarih = 0, a.Tarih,@BitTarih) -- program ilk çalýþtýðýnda bir aralýk girilmeden tüm kayýtlarý çekmek için
		Order By a.ID, Convert(Datetime ,a.Tarih); -- hem sýra hem tarihe artan þekilde yazdýrýlacak demiþtiniz. (Hala Sýra Numarasýndan kastýnýzýn galiba id alaný diyorum :) )
		
    SET @toplam = 0;

    OPEN cursor_stokMiktar;
    FETCH NEXT FROM cursor_stokMiktar INTO @siraNo, @islemTuru,@evrakNo,@tarih, @girisMiktar, @cikisMiktar, @islem, @stokMiktar

    WHILE @@FETCH_STATUS=0 
    BEGIN
	
        SET @toplam += IIF(@islem = 0, @stokMiktar, -@stokMiktar);
		INSERT INTO #BaseData  values (@siraNo,@islemTuru,@evrakNo,@tarih,@girisMiktar,@cikisMiktar,@toplam)

        FETCH NEXT FROM cursor_stokMiktar INTO @siraNo, @islemTuru,@evrakNo,@tarih, @girisMiktar, @cikisMiktar, @islem, @stokMiktar
    END

    CLOSE cursor_stokMiktar  
    DEALLOCATE cursor_stokMiktar  

	Select  *  from  #BaseData
	
 
END


 DROP TABLE #BaseData
