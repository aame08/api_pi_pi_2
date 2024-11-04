-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: trade
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturer` (
  `ManufacturerID` int NOT NULL,
  `Name` text,
  PRIMARY KEY (`ManufacturerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,'Esteban'),(2,'Home Philosophy'),(3,'Весна'),(4,'True Scents'),(5,'Valley'),(6,'Cube Color'),(7,'Umbra'),(8,'Miksdo'),(9,'Aroma'),(10,'Gallery'),(11,'Kersten');
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderproduct`
--

DROP TABLE IF EXISTS `orderproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderproduct` (
  `OrderProductID` varchar(45) NOT NULL,
  `OrderID` int NOT NULL,
  `ProductArticleNumber` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Count` int NOT NULL,
  PRIMARY KEY (`OrderProductID`),
  KEY `orderID_idx` (`OrderID`),
  KEY `productID_idx` (`ProductArticleNumber`),
  CONSTRAINT `orderID` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`),
  CONSTRAINT `productID` FOREIGN KEY (`ProductArticleNumber`) REFERENCES `product` (`ProductArticleNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderproduct`
--

LOCK TABLES `orderproduct` WRITE;
/*!40000 ALTER TABLE `orderproduct` DISABLE KEYS */;
INSERT INTO `orderproduct` VALUES ('1',1,'K478R4',10),('10',10,'D832R2',5),('11',1,'F933T5',5),('12',2,'D034T5',6),('13',3,'D826T5',11),('14',4,'D832R2',5),('15',5,'D044T5',5),('16',6,'F933T5',5),('17',7,'S039T5',3),('18',8,'F937R4',3),('19',9,'D826T5',2),('2',2,'S563T4',2),('20',10,'D044T5',2),('3',3,'K083T5',11),('4',4,'B037T5',1),('5',5,'R922T5',7),('6',6,'V783T5',1),('7',7,'H937R3',1),('8',8,'F903T5',4),('9',9,'R836R5',1);
/*!40000 ALTER TABLE `orderproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `OrderID` int NOT NULL AUTO_INCREMENT,
  `DispatchDate` datetime DEFAULT NULL,
  `DeliveryDate` datetime NOT NULL,
  `PointID` int NOT NULL,
  `UserID` int DEFAULT NULL,
  `Code` int DEFAULT NULL,
  `OrderStatusID` int NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `status_idx` (`OrderStatusID`),
  KEY `userID_idx` (`UserID`),
  KEY `pointID_idx` (`PointID`),
  CONSTRAINT `pointID` FOREIGN KEY (`PointID`) REFERENCES `point` (`PointID`),
  CONSTRAINT `status` FOREIGN KEY (`OrderStatusID`) REFERENCES `orderstatus` (`OrderStatusID`),
  CONSTRAINT `userID` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'2001-05-20 22:00:00','2007-05-20 22:00:00',2,51,111,1),(2,'2002-05-20 22:00:00','2008-05-20 22:00:00',8,51,112,1),(3,'2003-05-20 22:00:00','2009-05-20 22:00:00',10,51,113,1),(4,'2004-05-20 22:00:00','2010-05-20 22:00:00',12,51,114,2),(5,'2005-05-20 22:00:00','2011-05-20 22:00:00',15,51,115,1),(6,'2006-05-20 22:00:00','2012-05-20 22:00:00',18,52,116,1),(7,'2007-05-20 22:00:00','2013-05-20 22:00:00',20,52,117,2),(8,'2008-05-20 22:00:00','2014-05-20 22:00:00',25,52,118,1),(9,'2009-05-20 22:00:00','2015-05-20 22:00:00',30,52,119,2),(10,'2010-05-20 22:00:00','2016-05-20 22:00:00',36,53,120,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatus`
--

DROP TABLE IF EXISTS `orderstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatus` (
  `OrderStatusID` int NOT NULL,
  `Name` text,
  PRIMARY KEY (`OrderStatusID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatus`
--

LOCK TABLES `orderstatus` WRITE;
/*!40000 ALTER TABLE `orderstatus` DISABLE KEYS */;
INSERT INTO `orderstatus` VALUES (1,'Новый '),(2,'Завершен');
/*!40000 ALTER TABLE `orderstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `point`
--

DROP TABLE IF EXISTS `point`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `point` (
  `PointID` int NOT NULL,
  `Postcode` int DEFAULT NULL,
  `Address` text,
  PRIMARY KEY (`PointID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `point`
--

LOCK TABLES `point` WRITE;
/*!40000 ALTER TABLE `point` DISABLE KEYS */;
INSERT INTO `point` VALUES (1,344288,'г.Ковров ул. Чехова 1'),(2,614164,'г.Ковров ул. Степная 30'),(3,394242,'г.Ковров ул. Коммунистическая 43'),(4,660540,'г.Ковров ул. Солнечная 25'),(5,125837,'г.Ковров ул. Шоссейная 40'),(6,125703,'г.Ковров ул. Партизанская 49'),(7,625283,'г.Ковров ул. Победы 46'),(8,614611,'г.Ковров ул. Молодежная 50'),(9,454311,'г.Ковров ул. Новая 19'),(10,660007,'г.Ковров ул. Октябрьская 19'),(11,603036,'г.Ковров ул. Садовая 4'),(12,450983,'г.Ковров ул. Комсомольская 26'),(13,394782,'г.Ковров ул. Чехова 3'),(14,603002,'г.Ковров ул. Дзержинского 28'),(15,450558,'г.Ковров ул. Набережная 30'),(16,394060,'г.Ковров ул. Фрунзе 43'),(17,410661,'г.Ковров ул. Школьная 50'),(18,625590,'г.Ковров ул. Коммунистическая 20'),(19,625683,'г.Ковров ул. 8Марта '),(20,400562,'г.Ковров ул. Зеленая 32'),(21,614510,'г.Ковров ул. Маяковского 47'),(22,410542,'г.Ковров ул. Светлая 46'),(23,620839,'г.Ковров ул. Цветочная 8'),(24,443890,'г.Ковров ул. Коммунистическая 1'),(25,603379,'г.Ковров ул. Спортивная 46'),(26,603721,'г.Ковров ул. Гоголя 41'),(27,410172,'г.Ковров ул. Северная 13'),(28,420151,'г.Ковров ул. Вишневая 32'),(29,125061,'г.Ковров ул. Подгорная 8'),(30,630370,'г.Ковров ул. Шоссейная 24'),(31,614753,'г.Ковров ул. Полевая 35'),(32,426030,'г.Ковров ул. Маяковского 44'),(33,450375,'г.Ковров ул. Клубная 44'),(34,625560,'г.Ковров ул. Некрасова 12'),(35,630201,'г.Ковров ул. Комсомольская 17'),(36,190949,'г.Ковров ул. Мичурина 26');
/*!40000 ALTER TABLE `point` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `ProductArticleNumber` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` text NOT NULL,
  `Measure` varchar(45) NOT NULL,
  `Cost` decimal(19,4) NOT NULL,
  `Description` text,
  `ProductTypeID` int NOT NULL,
  `Photo` text,
  `SupplierID` int NOT NULL,
  `ProductMaxDiscount` int DEFAULT NULL,
  `ManufacturerID` int NOT NULL,
  `CurrentDiscount` int DEFAULT NULL,
  `Status` text NOT NULL,
  `QuantityInStock` int NOT NULL,
  PRIMARY KEY (`ProductArticleNumber`),
  KEY `sup_idx` (`SupplierID`),
  KEY `manufac_idx` (`ManufacturerID`),
  KEY `productType_idx` (`ProductTypeID`),
  CONSTRAINT `manufac` FOREIGN KEY (`ManufacturerID`) REFERENCES `manufacturer` (`ManufacturerID`),
  CONSTRAINT `productType` FOREIGN KEY (`ProductTypeID`) REFERENCES `producttype` (`ProductTypeID`),
  CONSTRAINT `sup` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`SupplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('B025Y5','Блюдо','шт.',1890.0000,'Блюдо декоративное flower 35 см Home Philosophy',8,'',1,5,2,3,'',8),('B037T5','Блюдо','шт.',690.0000,'Блюдо декоративное Flower 35 см',8,'',1,5,2,2,'',14),('D034T5','Диффузор','шт.',800.0000,'Диффузор Mikado intense Апельсин с корицей',1,'D034T5.jpg',2,20,8,2,'',15),('D044T5','Декор настенный','шт.',1790.0000,'Декор настенный Фантазия 45х45х1 см',8,'',1,5,2,3,'',7),('D826T5','Диффузор','шт.',600.0000,'Диффузор True Scents 45 мл манго',1,'',2,5,4,2,'',13),('D832R2','Растение','шт.',1000.0000,'Декоративное растение 102 см',8,'',1,10,2,3,'',15),('D947R5','Диффузор','шт.',500.0000,'Диффузор Aroma Harmony Lavender',1,'',2,5,9,4,'',6),('F837T5','Фоторамка','шт.',999.0000,'Шкатулка для украшений из дерева Stowit',6,'',2,5,10,2,'',15),('F903T5','Фоторамка','шт.',600.0000,'Фоторамка Gallery 20х30 см',6,'',2,15,10,2,'',3),('F928T5','Фоторамка','шт.',1590.0000,'Фоторамка Prisma 10х10 см',6,'',1,25,7,2,'',13),('F933T5','Кашпо','шт.',1400.0000,'Настольное кашпо с автополивом Cube Color',4,'F933T5.jpg',2,20,6,4,'',23),('F937R4','Фоторамка','шт.',359.0000,'Фоторамка 10х15 см Gallery серый с патиной/золотой',6,'',2,15,10,4,'',17),('H023R8','Часы','шт.',5600.0000,'Часы настенные Ribbon 30,5 см',5,'H023R8.jpg',1,15,7,2,'',6),('H937R3','Часы','шт.',999.0000,'Часы настенные 6500 30,2 см',5,'H937R3.jpg',2,10,7,3,'',4),('K083T5','Аромат','шт.',2790.0000,'Сменный аромат Figue noire 250 мл',1,'',1,20,1,2,'',6),('K478R4','Аромат','шт.',3500.0000,'Аромат для декобукета Esteban',1,'K478R4.jpg',1,30,1,4,'',4),('K937T4','Аромат','шт.',7900.0000,'Деко-букет Кедр 250 мл',1,'',1,25,1,2,'',17),('P846R4','Подставка','шт.',1400.0000,'Подставка для цветочных горшков 55x25x35 см Valley',4,'',1,15,5,3,'',12),('P927R2','Подставка','шт.',4000.0000,'Подставка для цветочных горшков Valley',4,'P927R2.jpg',1,15,5,2,'',4),('P936E4','Подставка','шт.',3590.0000,'Подставка для газет и журналов Zina',4,'P936E4.jpg',1,15,7,4,'',9),('R836R5','Шкатулка','шт.',8000.0000,'Шкатулка для украшений из дерева Stowit',7,'',1,30,7,5,'',3),('R922T5','Шкатулка','шт.',690.0000,'Шкатулка из керамики Lana 6х7 см',7,'',1,10,2,2,'',4),('S039T5','Свеча','шт.',250.0000,'Свеча True Moods Feel happy',3,'',2,10,4,2,'',18),('S563T4','Свеча','шт.',1000.0000,'Свеча в стакане True Scents',3,'S563T4.jpg',2,20,4,3,'',12),('S936Y5','Свеча','шт.',299.0000,'Свеча в стакане True Scents',1,'',2,15,4,3,'',4),('S937T5','Подсвечник','шт.',2600.0000,'Подсвечник 37 см',1,'',1,10,11,3,'',23),('V432R6','Ваза','шт.',1990.0000,'Ваза из фаянса 28,00 x 9,50 x 9,50 см',2,'',1,10,11,3,'',30),('V483R7','Ваза','шт.',100.0000,'Ваза «Весна» 18 см стекло, цвет прозрачный',2,'V483R7.jpg',2,15,3,3,'',7),('V783T5','Ваза','шт.',1300.0000,'Ваза из керамики Betty',2,'V783T5.jpg',1,25,2,2,'',13),('V937E4','Ваза','шт.',1999.0000,'Ваза 18H2535S 30,5 см',2,'',2,15,11,3,'',21);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producttype`
--

DROP TABLE IF EXISTS `producttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producttype` (
  `ProductTypeID` int NOT NULL,
  `Name` text,
  PRIMARY KEY (`ProductTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producttype`
--

LOCK TABLES `producttype` WRITE;
/*!40000 ALTER TABLE `producttype` DISABLE KEYS */;
INSERT INTO `producttype` VALUES (1,'Ароматы для дома'),(2,'Вазы'),(3,'Свечи'),(4,'Горшки и подставки'),(5,'Часы'),(6,'Картины и фоторамки'),(7,'Шкатулки и подставки'),(8,'Интерьерные аксессуары');
/*!40000 ALTER TABLE `producttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Клиент'),(2,'Администратор'),(3,'Менеджер'),(4,'Гость');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier` (
  `SupplierID` int NOT NULL,
  `Name` text,
  PRIMARY KEY (`SupplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Стокманн'),(2,'Hoff');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Surname` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Patronymic` varchar(100) NOT NULL,
  `Login` text,
  `Password` text,
  `Role` int NOT NULL,
  PRIMARY KEY (`UserID`),
  KEY `user_ibfk_1` (`Role`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`Role`) REFERENCES `role` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Алексеев ','Владислав','Аркадьевич','loginDEbct2018','Qg3gff',1),(2,'Савельева ','Евфросиния','Арсеньевна','loginDEvtg2018','ETMNzL',2),(3,'Никонов ','Мэлс','Лукьевич','loginDEuro2018','a1MIcO',1),(4,'Горшкова ','Агафья','Онисимовна','loginDEpst2018','0CyGnX',1),(5,'Горбачёв ','Пантелеймон','Германович','loginDEpsu2018','Vx9cQ{',3),(6,'Ершова ','Иванна','Максимовна','loginDEzqs2018','qM9p7i',3),(7,'Туров ','Денис','Геласьевич','loginDEioe2018','yMPu&2',3),(8,'Носова ','Наина','Эдуардовна','loginDEcmk2018','3f+b0+',2),(9,'Куликов ','Андрей','Святославович','loginDEfsp2018','&dtlI+',1),(10,'Нестеров ','Агафон','Георгьевич','loginDExcd2018','SZXZNL',1),(11,'Козлов ','Геласий','Христофорович','loginDEvlf2018','O5mXc2',3),(12,'Борисова ','Анжелика','Анатольевна','loginDEanv2018','Xiq}M3',2),(13,'Суханов ','Станислав','Фролович','loginDEzde2018','tlO3x&',3),(14,'Тетерина ','Феврония','Эдуардовна','loginDEriv2018','GJ2mHL',3),(15,'Муравьёва ','Александра','Ростиславовна','loginDEhcp2018','n2nfRl',3),(16,'Новикова ','Лукия','Ярославовна','loginDEwjv2018','ZfseKA',3),(17,'Агафонова ','Лариса','Михаиловна','loginDEiry2018','5zu7+}',3),(18,'Сергеева ','Агата','Юрьевна','loginDEgbr2018','}+Ex1*',3),(19,'Колобова ','Елена','Евгеньевна','loginDExxv2018','+daE|T',3),(20,'Ситников ','Николай','Филатович','loginDEbto2018','b1iYMI',1),(21,'Белов ','Роман','Иринеевич','loginDEfbs2018','v90Rep',3),(22,'Волкова ','Алла','Лукьевна','loginDEple2018','WlW+l8',2),(23,'Кудрявцева ','Таисия','Игоревна','loginDEhhx2018','hmCHeQ',3),(24,'Семёнова ','Октябрина','Христофоровна','loginDEayn2018','Ka2Fok',3),(25,'Смирнов ','Сергей','Яковович','loginDEwld2018','y9HStF',3),(26,'Брагина ','Алина','Валерьевна','loginDEhuu2018','X31OEf',1),(27,'Евсеев ','Игорь','Донатович','loginDEmjb2018','5mm{ch',3),(28,'Суворов ','Илья','Евсеевич','loginDEdgp2018','1WfJjo',3),(29,'Котов ','Денис','Мартынович','loginDEgyi2018','|7nYPc',2),(30,'Бобылёва ','Юлия','Егоровна','loginDEmvn2018','Mrr9e0',1),(31,'Брагин ','Бронислав','Георгьевич','loginDEfoj2018','nhGc+D',2),(32,'Александров ','Владимир','Дамирович','loginDEuuo2018','42XmH1',1),(33,'Фокин ','Ириней','Ростиславович','loginDEhsj2018','s+jrMW',1),(34,'Воронов ','Митрофан','Антонович','loginDEvht2018','zMyS8Z',1),(35,'Маслов ','Мстислав','Антонинович','loginDEeqo2018','l5CBqA',1),(36,'Щербаков ','Георгий','Богданович','loginDExrf2018','mhpRIT',1),(37,'Кириллова ','Эмилия','Федосеевна','loginDEfku2018','a1m+8c',3),(38,'Васильев ','Серапион','Макарович','loginDExix2018','hzxtnn',2),(39,'Галкина ','Олимпиада','Владленовна','loginDEqrf2018','mI8n58',3),(40,'Яковлева ','Ксения','Онисимовна','loginDEhlk2018','g0jSed',1),(41,'Калашникова ','Александра','Владимировна','loginDEwoe2018','yOtw2F',2),(42,'Медведьева ','Таисия','Тихоновна','loginDExyu2018','7Fg}9p',1),(43,'Карпова ','Ольга','Лукьевна','loginDEcor2018','2cIrC8',1),(44,'Герасимов ','Мстислав','Дамирович','loginDEqon2018','YeFbh6',3),(45,'Тимофеева ','Ксения','Валерьевна','loginDEyfd2018','8aKdb0',1),(46,'Горбунов ','Вячеслав','Станиславович','loginDEtto2018','qXYDuu',3),(47,'Кошелева ','Кира','Владиславовна','loginDEdal2018','cJWXL0',3),(48,'Панфилова ','Марина','Борисовна','loginDEbjs2018','Xap2ct',3),(49,'Кудрявцев ','Матвей','Игоревич','loginDEdof2018','kD|LRU',3),(50,'Зуев ','Эдуард','Пантелеймонович','loginDEsnh2018','Dkgs25|',3),(51,'Архипова','Оливия','Дмитриевна','','',4),(52,'Никонова','Татьяна','Захаровна','','',4),(53,'Рябова','Диана','Павловна','','',4);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-16 10:24:38
