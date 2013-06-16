/*
SQLyog Ultimate v8.71 
MySQL - 5.5.25 : Database - redcross
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`redcross` /*!40100 DEFAULT CHARACTER SET gb2312 */;

USE `redcross`;

/*Table structure for table `db_activity` */

DROP TABLE IF EXISTS `db_activity`;

CREATE TABLE `db_activity` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `publishTime` datetime NOT NULL,
  `isactive` tinyint(4) NOT NULL DEFAULT '0',
  `preStart` datetime DEFAULT NULL,
  `overEnd` datetime DEFAULT NULL,
  `isVisitApply` tinyint(4) NOT NULL DEFAULT '0',
  `contentDetails` varchar(250) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_activity` */

insert  into `db_activity`(`id`,`content`,`publishTime`,`isactive`,`preStart`,`overEnd`,`isVisitApply`,`contentDetails`) values (1,'制作红会网站','2012-06-23 00:00:00',1,'2010-10-10 00:00:00','2013-10-10 00:00:00',0,'红会将制作自己的专属网站，上面会记录红会的点点滴滴，及时提供红会的活动消息，方便大家参与。同时也让会内成员更好的安排活动，提供红会的效率等。敬请期待。'),(6,'2012年冬季总结大会','2012-10-10 00:00:00',1,'2012-10-10 00:00:00','2013-12-28 00:00:00',1,'又到了每一个学期的总结大会，我们将总结这一学期红会的成长和不足，在下一个学期，我们会为大家提供更好的活动和服务。地点在励耘楼A201，晚上7点开始，欢迎各位童鞋围观。'),(7,'救护考试','2012-11-04 00:00:00',1,'2012-11-04 00:00:00','2013-12-21 00:00:00',1,'验证你的救护知识的时候到了，祝愿大家都能顺利通过。无需考试的童鞋也非常欢迎前来，当做复习救护知识。地点在丽泽楼B101，晚上7点开始。'),(8,'救护知识实际操练 ','2012-11-11 00:00:00',1,'2013-01-12 00:00:00','2013-05-01 00:00:00',1,'大家学习完救护知识有没好好复习呢，红会在这周六晚上丽泽楼C102举办救护知识实际操练活动，欢迎各位童鞋围观，熟悉救护知识与不熟悉都可以来参加噢。'),(9,'18日探访敬老院','2012-12-18 00:00:00',1,'2012-11-18 00:00:00','2013-12-30 00:00:00',1,'18日即本周六探访唐家敬老院，集合时间地点：上午10点在校名石');

/*Table structure for table `db_article` */

DROP TABLE IF EXISTS `db_article`;

CREATE TABLE `db_article` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `body` varchar(20000) DEFAULT NULL,
  `publishTime` datetime DEFAULT NULL,
  `author` varchar(16) DEFAULT NULL,
  `reprintName` varchar(16) DEFAULT NULL,
  `reprintAdress` varchar(100) DEFAULT NULL,
  `summary` varchar(400) DEFAULT NULL,
  `ispass` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=gb2312;

/*Data for the table `db_article` */

insert  into `db_article`(`id`,`title`,`body`,`publishTime`,`author`,`reprintName`,`reprintAdress`,`summary`,`ispass`) values (2,'水中抽筋的自救','前段时间caoz写过一篇博客点评刘韧的事情，\n 不曾想若干个江湖大佬级的人物都和caoz提到了这个文章，\n 他们不约而同的说这是互联网上点评刘韧最好的文章，其中说得最好的就是心态。\n 这些人都是曾经和刘韧过往甚密的人，他们知道的内情远比caoz丰富而且准确，\n 那么caoz写文章的时候还不曾把这个看的太透彻，得到如此反馈之后反而加深了体会，\n 一个人能不能做成事，能不能有成就，能有怎样的成就，还真就是一个心态问题。\n <br />有不止一个牛X人物说caoz最大的缺点就是太聪明，所谓太聪明，就是想法太多，获取的信息也多，\n 获取信息的渠道也多，所以总是在不断的选择和判断，却失去了专注和执着。caoz想来，极为有理。<br />这些年来，\n 不断的反思自己，为什么不曾有所作为？是水平不足，眼光不准？脑子不够灵光？貌似都不是，说到底，还是心态问题，\n 不够专注，不够简单，不够扎实。<br />反思之后，caoz找到了两个榜样，caoz这样一向嚣张高傲的人是很少服人的，\n 但是这些年反躬自省，才发现真正的楷模其实一直就在身边，这两个人，一个叫做李兴平，一个叫做俞军，是的，\n 他们都很默默无名，都不是那种媒体热衷的人物，也不喜欢侃侃而谈。但是他们才是真正了不起的人物。\n 百度有今天的成就，贡献最大的也就是这两个人了）<br />李兴平和俞军，caoz认为，都不是天才，不是那种智商很高，\n 无所不能的家伙，所以如果你初次和他们接触，往往会觉得也没什么了不起（caoz开始真就是这么觉得的），共性，\n 多做少说，甚至不说，但是最关键的是，他们做事情的心态, 简单总结就是,把简单的事情做好。\n <br />之前吴鲁加同学分享过一篇文章，好的道理从来都是简简单单，能做好一件事情，能做出成就，\n 是否需要惊人的才能？其实不是，但是有多少人，真的肯踏踏实实，一步一个脚印的把简单的事情做好。\n <br />好，caoz举个例子，假如说，有一种网络服务，有100家提供相同的内容和产品，你想脱颖而出，\n 成为这里规模最大，用户最多的，怎么办？无数聪明人会出无数聪明点子，增加功能，提供差异化服务，\n 等等等等，其实告诉你，很简单，你比其他99家的速度更快，质量更好，稳定性更好，就够了，真的就够了。\n 可是有多少人做到了？于是聪明人还在那里找各种原因，找各种理由。<br />执着，专注，\n 把简单的事情做好，阿甘可以成功，许三多也可以成功，何况你我。','2012-04-04 10:52:54','毕淑敏','猪猪网','www.zuzu.com','当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(3,'无家可归女生考上哈佛 靠当清洁工完成学业',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(4,'萨姆.劳埃德的数学趣题续编',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(5,'二十岁的人应该读懂60本书',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(6,'教你如何进入深度睡眠',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(7,'所罗门王的智慧',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(8,'会自动叠被子的床 ? 以后再也不愁叠被子了，简直是懒人福音',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(9,'《绿箭侠》曝全新预告&海报 大反派丧钟现身 ',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(10,'程序猿国度的15位高富帅+白富美',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(11,'20大改变生活的研究项目',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(12,'毕淑敏：我很重要',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(13,'伟大与优秀的区别 - 详解暴雪成功背后的秘密',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(14,'?丝们翻身的机会来了，玩好《暗黑3》买海景房不是梦！',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(15,'无家可归女生考上哈佛 靠当清洁工完成学业',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(16,'为何说雨果是阿凡达后最好的3D电影',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(17,'世界经典趣题',NULL,'2012-04-04 10:52:54','毕淑敏',NULL,NULL,'当我说出“我很重要”这句话的时候，颈项后面掠过一阵战栗。我知道这是把自己的额头裸露在弓箭之下了，心灵极容易被别人的批判洞伤。许多年来，没有人敢在光天化日之下表示自己“很重要”。我们从小受到的教育都是“我不重要”。',1),(18,'有没有这么一个人，你无数次说着要放弃，但终究还是舍不得？',NULL,'2012-04-04 10:52:54','小虫子',NULL,NULL,'每个人都有着属于自己的爱情、每个人都会有自己的幸福、然而幸福的道路、却并不是一模一样的、有的人只有经历风雨后、才能看到远方的彩虹！ ',1),(19,'一个女孩的五年',NULL,'2012-04-04 10:52:54','南方南方',NULL,NULL,'这是个真实的故事，我在豆瓣上看着这个女孩娓娓道来她的5年，突然觉得这个世界很无奈，只希望我们都能珍惜自己身边的人.. ',1),(20,'瓦尔登湖','“我希望世界上的人，越不相同越好；但是我愿意每一个人都能谨慎地找出并坚持他自己的合适方式，而不要采用他父亲的，或母亲的，或邻居的方式。”梭罗的方式是，到瓦尔登湖边去，“只面对生活的基本事实，看看我是否学得到生活要教育我的东西”。你当然不必像他。','2012-04-04 10:52:54','梭罗',NULL,NULL,'“我希望世界上的人，越不相同越好；但是我愿意每一个人都能谨慎地找出并坚持他自己的合适方式，而不要采用他父亲的，或母亲的，或邻居的方式。”梭罗的方式是，到瓦尔登湖边去，“只面对生活的基本事实，看看我是否学得到生活要教育我的东西”。你当然不必像他。',1);

/*Table structure for table `db_collage` */

DROP TABLE IF EXISTS `db_collage`;

CREATE TABLE `db_collage` (
  `collageid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `collagename` char(10) NOT NULL,
  PRIMARY KEY (`collageid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=gb2312;

/*Data for the table `db_collage` */

insert  into `db_collage`(`collageid`,`collagename`) values (1,'信息技术学院'),(2,'文学院'),(3,'房地产'),(4,'工程技术学院'),(5,'特许经营学院'),(6,'应用数学'),(7,'物流学院'),(8,'教育学院'),(9,'管理学院'),(10,'外国语'),(11,'艺术与传播学院'),(12,'国际金融'),(13,'国际工商');

/*Table structure for table `db_controlleraction` */

DROP TABLE IF EXISTS `db_controlleraction`;

CREATE TABLE `db_controlleraction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` char(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `isController` tinyint(1) DEFAULT '0',
  `isAllowedNoneRoles` tinyint(1) DEFAULT NULL,
  `isAllowedAllRoles` tinyint(1) DEFAULT NULL,
  `ControlerName` char(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_controlleraction` */

insert  into `db_controlleraction`(`id`,`name`,`isController`,`isAllowedNoneRoles`,`isAllowedAllRoles`,`ControlerName`) values (1,'Index',0,1,0,'Article'),(2,'Detail',0,1,0,'Article'),(3,'Shared',1,0,0,NULL),(4,'Add',0,0,1,'TimeTable'),(5,'Detail',0,0,1,'TimeTable'),(7,'Search',0,0,1,'TimeTable'),(8,'SearchResult',0,0,1,'TimeTable'),(9,'Update',0,0,0,'TimeTable'),(10,'Detail',0,0,1,'User'),(11,'Login',0,1,0,'User'),(12,'PersonalHome',0,0,1,'User'),(13,'Register',0,1,0,'User'),(14,'PermissionNewUser',0,0,0,'User'),(15,'Details',0,1,0,'Work'),(16,'Add',0,0,0,'Work'),(17,'Update',0,0,0,'Work'),(18,'Details',0,1,0,'Activity'),(19,'Add',0,0,0,'Activity'),(20,'Update',0,0,0,'Activity'),(21,'Details',0,1,0,'Department'),(22,'Add',0,0,0,'Department'),(23,'Update',0,0,0,'Department'),(24,'Details',0,1,0,'Family'),(25,'Add',0,0,0,'Family'),(26,'Update',0,0,0,'Family'),(27,'Details',0,1,0,'ImportantEvent'),(28,'Add',0,0,0,'ImportantEvent'),(29,'Update',0,0,0,'ImportantEvent'),(30,'Details',0,1,0,'Notice'),(31,'Add',0,0,0,'Notice'),(32,'Update',0,0,0,'Notice'),(33,'GetUserTimeTable',0,0,0,'TimeTable');

/*Table structure for table `db_controlleractionrole` */

DROP TABLE IF EXISTS `db_controlleractionrole`;

CREATE TABLE `db_controlleractionrole` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `isAllowed` tinyint(1) DEFAULT NULL,
  `roleId` int(10) DEFAULT NULL,
  `ControllerActionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_roleId` (`roleId`),
  KEY `fk_controllerActionId` (`ControllerActionId`),
  CONSTRAINT `fk_controllerActionId` FOREIGN KEY (`ControllerActionId`) REFERENCES `db_controlleraction` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_roleId` FOREIGN KEY (`roleId`) REFERENCES `db_role` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_controlleractionrole` */

insert  into `db_controlleractionrole`(`id`,`isAllowed`,`roleId`,`ControllerActionId`) values (1,1,5,9),(2,1,6,9),(3,1,2,9),(4,1,7,9),(5,1,2,16),(6,1,2,17),(7,1,2,19),(8,1,2,20),(9,1,2,22),(10,1,2,23),(11,1,2,25),(12,1,2,26),(13,1,2,28),(14,1,2,29),(15,1,2,31),(16,1,2,32),(17,1,2,14),(18,1,7,14),(19,1,5,14),(20,1,6,14),(22,1,7,16),(23,1,5,16),(24,1,6,16),(25,1,7,17),(26,1,5,17),(27,1,6,17),(28,1,2,19),(29,1,7,20),(30,1,2,22),(31,1,7,23),(32,1,7,25),(33,1,5,25),(34,1,6,25),(35,1,7,26),(36,1,5,26),(37,1,6,26),(38,1,7,28),(39,1,7,29),(40,1,7,31),(41,1,7,32),(42,1,5,33),(43,1,6,33),(44,1,2,33),(45,1,7,33);

/*Table structure for table `db_department` */

DROP TABLE IF EXISTS `db_department`;

CREATE TABLE `db_department` (
  `depid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `depname` char(50) DEFAULT NULL,
  `depintroduction` varchar(2000) DEFAULT NULL,
  `weiboId` char(20) DEFAULT NULL,
  PRIMARY KEY (`depid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=gb2312;

/*Data for the table `db_department` */

insert  into `db_department`(`depid`,`depname`,`depintroduction`,`weiboId`) values (1,'红会','红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织.','1654675690'),(2,'宣传部','我们是北师珠校红会宣传部，负责红会活动的宣传工作，包括制作海报、传单，现场环境的有趣布置，新闻稿的撰写等。 ','2511432012'),(3,'办公室','我们是北师珠校红会办公室部，负责场地的申请，红会资料的整理，以及红会的文案等。','2514401894'),(4,'公益部','我们是北师珠校红会公益部，我们本着为人民服务的精神~','2512516124'),(5,'救护部','我们是北师珠校红会救护部，是一个团结友爱的集体，每天都会为你提供一些保持健康，急救以及红十培训有趣的信息等。 ','2518413674'),(6,'财务部','我们是北师珠校红会财务部，负责红会活动的支出和成员的报销，即管家婆，期待你的加入。 ','2514316472'),(7,'策划部','我们是北师珠校红会策划部，负责红会活动的规划、流程，主意多多的同学果断加入到我们部门吧。','2519234040'),(8,'其他','这。。',NULL);

/*Table structure for table `db_family` */

DROP TABLE IF EXISTS `db_family`;

CREATE TABLE `db_family` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` char(30) NOT NULL,
  `userName` char(15) NOT NULL,
  `sex` tinyint(4) NOT NULL,
  `grdId` int(10) unsigned NOT NULL,
  `clgId` int(10) unsigned NOT NULL,
  `depId` int(10) unsigned NOT NULL,
  `wish` varchar(500) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `depId` (`depId`),
  KEY `grdId` (`grdId`),
  KEY `clgId` (`clgId`),
  CONSTRAINT `FK_family_Dep` FOREIGN KEY (`depId`) REFERENCES `db_department` (`depid`) ON UPDATE CASCADE,
  CONSTRAINT `FK_family_Grade` FOREIGN KEY (`grdId`) REFERENCES `db_grade` (`grdid`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=gb2312;

/*Data for the table `db_family` */

insert  into `db_family`(`id`,`userId`,`userName`,`sex`,`grdId`,`clgId`,`depId`,`wish`) values (1,'0701030091','魏嘉鹏',1,1,1,2,'我爱红会，红会爱我，两情相悦，就等着领证了哇哈哈。'),(2,'0902060066','吴婉玲',0,3,9,3,'希望红会的活动越办越好，大家都能在这个是大家庭里收获友谊，快乐！'),(3,'0905010115','吴文致',0,3,2,3,'怀揣着同样的愿望，我们走到了一起。“人道、博爱、奉献”不仅仅是宗旨，也是我们每一个红会人的心愿。我相信，“小我”总有一天会聚成“大我”。风雨兼程，我们携手共进。'),(4,'0907030074','孙嘉欣',0,3,8,3,'希望红会越办越好~多开展点特色活动~'),(5,'0811010002','毕琪',0,2,7,3,'作为一个已经毕业了的红会老人，我在红会办公室里体会过很不一样的日子，每一个帮助过我的红会更有资历的学姐学长都在我的记忆里留下了无尽的想念，我心里充满感激，而对于以后的你们，我只是坚信，你们一定会越来越好，只可以超越我们哦~各种加油，在红会一定会让你们有所收获~ '),(6,'0818020122','刘俊兵',1,2,4,3,'庆幸自己加入红十字会这个充满爱的群体，不会忘记大家在红会的点点滴滴，人道，博爱，奉献，希望永远都是志愿者，爱红会，爱办公室。'),(7,'0905030035','黄转银',0,3,2,3,'希望红会能够不断进步，越来越好。办好我们的品牌活动，发掘更多更好的项目。会内希望各部门上下齐心、通力合作、奋发前进。'),(8,'0915010083','李鸿勋',0,3,10,3,'德兰修女曾经说过:\"我这一生做不到什么伟大事业，我只能用伟大的爱，尽我的力，做小事情。\"希望我们红十字会的每一个志愿者都可以真真切切传递爱的小事情，积沙成塔，共同努力，汇聚成撼动人心、流传百世的不朽故事。最后，祝院北师大珠海分校红十字会越办越好。'),(9,'0818020119','林永明',1,2,4,5,'红会，执着而顽强，在那些不经意的角落，我们仍能看到你们的身影。我们甚至感觉不到你们的存在，可你们却因你的挥动而飞扬，将生机与希望不断在阳光中绽放。'),(10,'0901010136','徐任优',1,3,1,3,'希望红会能够更好地发扬人道主义精神，谨记人道、博爱、奉献的宗旨，学习救护培训知识，办好各种社会服务活动，为推进红会的发展，以及帮助有需要的人士贡献自己的一份力量。'),(11,'0902020084','伍熙',1,3,9,3,'希望红会越来越好'),(12,'0907030082','王禧璇',0,3,8,3,'希望以后红会能越办越好，成为全校知名的组织，能更受大家的重视，并且所有知道红会的人都能给出许多正面的评价。不只是在学校，即使是在外界也能得到很好的评价。'),(13,'0918010185','张晓津',1,3,4,3,'祝红会大家庭的每一个成员都能抓住生活中的机会，活得更精彩！'),(14,'0911010028','程丽质',0,3,12,3,'孩纸们。感谢你们加入红会这个大家庭，正是因为你们的加入才使得公益之火能够源源不断的燃烧下去。而红会能赋予你们的东西需要你们自己置身其中去一点一点慢慢体验与领悟。谢谢你们。爱你们。'),(15,'0907020035','刘佳玲',0,3,8,5,'体验救护，感受快乐，收获友谊。'),(16,'0917020040','李岚岚',0,3,6,5,'在红会这片蓝天下生活，每天都会有温暖的阳光，因为这里的每一个人都有着因为同一份感动而流泪的眼睛和因为同一份喜悦而扬起的嘴角。'),(17,'0802030043','李阳',1,2,9,6,'改变世界，我们无需长大。北师红会人，携手人道，怀揣博爱，真诚奉献。北师红会的热情接力赛，没有终点，愿把我们的幸福延伸到更远的地方。');

/*Table structure for table `db_grade` */

DROP TABLE IF EXISTS `db_grade`;

CREATE TABLE `db_grade` (
  `grdid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `grdname` char(10) NOT NULL,
  PRIMARY KEY (`grdid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=gb2312;

/*Data for the table `db_grade` */

insert  into `db_grade`(`grdid`,`grdname`) values (1,'2007级'),(2,'2008级'),(3,'2009级'),(4,'2010级'),(5,'2011级'),(6,'2012级'),(7,'2013级');

/*Table structure for table `db_importantevent` */

DROP TABLE IF EXISTS `db_importantevent`;

CREATE TABLE `db_importantevent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` varchar(500) NOT NULL,
  `publishTime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=gb2312;

/*Data for the table `db_importantevent` */

insert  into `db_importantevent`(`id`,`content`,`publishTime`) values (1,'2012年北师大救护好声音视频宣传','2012-11-05 00:00:00'),(2,'2012年冬季总结大会','2012-12-28 00:00:00'),(3,'2012年冬季献血活动','2012-11-21 00:00:00'),(5,'2012年冬季救护培训','2012-12-23 00:00:00'),(6,'2012年冬季关艾行动','2012-12-02 00:00:00');

/*Table structure for table `db_notice` */

DROP TABLE IF EXISTS `db_notice`;

CREATE TABLE `db_notice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `publishTime` datetime NOT NULL,
  `ntype` tinyint(4) NOT NULL,
  `isTop` tinyint(4) DEFAULT '0',
  `isPreTop` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_notice` */

insert  into `db_notice`(`id`,`content`,`publishTime`,`ntype`,`isTop`,`isPreTop`) values (1,'红会网站初期展示（汗。。才初期展示，敢再慢点吗。。）','2012-06-23 00:00:00',4,1,0),(2,'10月19号（周五），我们将举行会员动员大会，届时珠海市红十字会的老师会过来跟大家见面哦，大家记得一定要来，我们会让大家确认会员资料，以便我们办理会员证。','2012-06-23 08:00:00',2,1,0),(3,'哈哈哈哈，少年！国庆敲代码吧~~~','2001-06-24 00:00:00',4,1,0),(4,'#珠海市红会会员资料收集#没填好资料的孩子们快来吧 办公室的孩子们在会同门口等着你们呢','2002-09-09 00:00:00',2,1,0),(5,'今日下午13：30我们将从学校出发，前往唐家湾敬老院探望爷爷奶奶','2012-09-09 00:00:00',4,1,0),(6,'#大型献血活动#各位同学，这个学期的献血活动来了，11月21、22日，地点是图书馆门前，欢迎大家踊跃参与【做我们能做的，你的热血，将成为别人重生的希望。】','2012-11-03 00:00:00',2,0,0),(7,'会员动员大会开始咯大家还不快来填会员资料表！！！记得带照片哦珠海市红十字会@我爱红十字 秘书长来跟我们介绍红会啊','2012-10-19 00:00:00',2,0,0),(8,'所谓幸福，是有一颗感恩的心，一个健康的身体，一份称心的工作，一位深爱你的爱人，一帮值得信赖的朋友。','2012-09-09 00:00:00',2,0,0),(9,'不管全世界所有人怎么说，我都认为自己的感受才是正确的。无论别人怎么看，我绝不打乱自己的节奏。喜欢的事自然可以坚持，不喜欢的怎么也长久不了。——村上春树','2012-09-09 00:00:00',2,0,0),(10,'得之坦然，失之淡然，顺其自然，争其必然','2010-10-10 00:00:00',2,0,0),(11,'各位可爱的干事门，急救包到咯部长门什么时候给你们呢北师红会专用哦','2010-10-10 00:00:00',2,0,0),(12,'#会员大会#昨天晚上，我们正式宣誓加入红十字会后，大家都领到志愿者证了，各位有爱的同学们也就正式成为红十字会的志愿者，希望大家遵循誓言，做一位有爱、合格的志愿者，我们北师大珠海分校红十字会，会给大家打造一个【属于你们的公益、救护平台】更多活动，敬请关注@北师大珠海分校红十字会','2012-10-20 00:00:00',2,1,0),(13,' #红会会员大会-我们在一起#一年一度的会员大会即将举行，届时会员们会正式宣誓加入红十字会，并且发放会员证，当晚还有精彩的文艺演出，到场的会员还有机会获得【红会的急救包！！】我们还会预告接下来的活动，欢迎各位会员、同学们亲临现场，找到属于你的公益、救护活动！！详情请看海报。','2012-10-20 00:00:00',4,1,0),(14,'#会员救护培训#第一次会员救护培训，你在这里吗？大家都在练习哦！！','2012-10-20 00:00:00',2,0,0),(15,'看透的人，处处是生机；看不透的人，处处是困境。拿得起的人，处处是担当；拿不起的人，处处是疏忽。想得开的人，处处是春天；想不开的人，处处是凋枯。------做什么样的人，决定权在自己；有什么样的生活，决定权也在自己。','2012-10-20 00:00:00',2,0,0),(16,'别让别人告诉你不能做什么。人们自己做不成什么事情，就想告诉你你也做不成。如果你有个梦想，就必须去捍卫它。——《当幸福来敲门》 11月1日','2012-11-01 00:00:00',2,0,0),(17,'你若努力，就储存了一个希望；你若微笑，就储存了一份快乐。你能支取什么，取决于你储蓄了什么。没有储存学识，就无法支取能力；没有储存汗水，就无法支取成功。想要有取之不尽的幸福，就要每天储蓄感恩和付出。10月24日，晴23°~30°，微风','2012-10-24 00:00:00',2,0,0),(18,' #常识点点通#【止嗝小妙招】1吃一大口醋，立竿见影。2深吸一口气，憋住，弯腰90度，缓慢呼气，重复10—15次。3用干净的勺子把舌头压住，几分钟后打嗝会停。4喝一大杯温水。5抱双膝并压迫胸部','2012-10-20 00:00:00',4,0,0),(19,' #微益中国#我们这里有一群最需要帮助的可爱的孩子们，他们只需要一些小小的帮助。或许这些对于许多人来说是微不足道，但是对于他们来说就显得尤为重要了。一份爱心，收获一份希望。希望有更多的人来关注和帮助这些孩子们 ！携手@我们的微益中国 一起来关注乡村孩子的需求！','2012-10-20 00:00:00',2,0,0),(20,'每一枚玫瑰都有刺，正如每个人的性格里，都有你不能容忍的部分。爱护每一朵玫瑰，并不是得努力的把它的刺根除，只能学习如何不被她的刺刺伤，还有，如何不让自己的刺刺伤别人——《玫瑰花的哲学》10月25日','2012-10-21 00:00:00',2,0,0),(21,'想一千次，不如去做一次。华丽的跌倒，胜过无谓的徘徊。10月26日','2012-10-26 00:00:00',2,0,0),(23,'#三校救护好声音#现在开始咯有兴趣的同学现在还可以来呐！！！在励耘A302,三间高校的救护精英，都云集北师进行大考核咯，希望三间高校的孩子们都可以通过这次的考验啦啦啦啦@中山大学珠海校区红十字会 @北理珠青协红十字队','2012-10-19 00:00:00',2,1,0),(24,'未来公告，明天的^_^','2012-11-06 00:00:00',2,0,1);

/*Table structure for table `db_role` */

DROP TABLE IF EXISTS `db_role`;

CREATE TABLE `db_role` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `roleName` char(10) CHARACTER SET gb2312 NOT NULL,
  `description` varchar(25) CHARACTER SET gb2312 DEFAULT NULL,
  `isAdd` tinyint(4) DEFAULT '0',
  `isdelete` tinyint(4) DEFAULT '0',
  `isupdate` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_role` */

insert  into `db_role`(`id`,`roleName`,`description`,`isAdd`,`isdelete`,`isupdate`) values (1,'无',NULL,0,0,0),(2,'管理员',NULL,1,1,1),(3,'干事',NULL,0,0,0),(5,'副部长',NULL,1,1,1),(6,'正部长',NULL,1,1,1),(7,'会长',NULL,1,1,1),(8,'助理',NULL,1,1,1);

/*Table structure for table `db_user_comment` */

DROP TABLE IF EXISTS `db_user_comment`;

CREATE TABLE `db_user_comment` (
  `id` int(11) NOT NULL,
  `userComment` varchar(200) NOT NULL,
  `commentDatetime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

/*Data for the table `db_user_comment` */

/*Table structure for table `db_user_timetable` */

DROP TABLE IF EXISTS `db_user_timetable`;

CREATE TABLE `db_user_timetable` (
  `id` int(10) unsigned NOT NULL,
  `class` smallint(2) NOT NULL,
  `firstDay` char(1) DEFAULT NULL,
  `secondDay` char(1) DEFAULT NULL,
  `thirdDay` char(1) DEFAULT NULL,
  `fourthDay` char(1) DEFAULT NULL,
  `fifthDay` char(1) DEFAULT NULL,
  `sixthDay` char(1) DEFAULT NULL,
  `seventhDay` char(1) DEFAULT NULL,
  PRIMARY KEY (`id`,`class`),
  CONSTRAINT `fk_user_id` FOREIGN KEY (`id`) REFERENCES `db_users` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

/*Data for the table `db_user_timetable` */

insert  into `db_user_timetable`(`id`,`class`,`firstDay`,`secondDay`,`thirdDay`,`fourthDay`,`fifthDay`,`sixthDay`,`seventhDay`) values (1,1,'1','0','1','0','0','0','1'),(1,2,'1','0','1','0','0','0','1'),(1,3,'1','1','0','1','1','0','1'),(1,4,'1','1','0','1','1','0','1'),(1,5,'1','0','0','1','1','0','0'),(1,6,'1','0','0','1','1','0','0'),(1,7,'1','0','0','0','1','0','1'),(1,8,'1','0','0','0','1','0','1'),(1,9,'1','0','0','0','0','0','1'),(1,10,'0','1','1','0','0','0','1'),(1,11,'0','1','1','0','0','0','1'),(1,12,'0','1','1','0','0','0','1'),(1,13,'0','1','1','0','0','0','0'),(5,1,'0','1','1','1','1','0','0'),(5,2,'0','1','1','1','1','0','0'),(5,3,'1','0','1','1','1','0','0'),(5,4,'1','0','1','1','1','0','0'),(5,5,'0','0','1','0','0','0','0'),(5,6,'0','0','1','0','0','0','0'),(5,7,'1','0','0','1','1','0','0'),(5,8,'1','0','0','1','1','0','0'),(5,9,'0','0','0','0','1','0','0'),(5,10,'0','1','0','0','0','0','0'),(5,11,'0','1','0','0','0','0','0'),(5,12,'0','0','0','0','0','0','0'),(5,13,'0','0','0','0','0','0','0'),(6,1,'0','1','0','0','1','0','0'),(6,2,'0','1','0','0','1','0','0'),(6,3,'0','1','1','0','1','0','0'),(6,4,'0','1','1','0','1','0','0'),(6,5,'0','1','1','0','0','0','0'),(6,6,'0','1','1','0','0','0','0'),(6,7,'1','1','1','0','0','0','0'),(6,8,'1','1','1','0','0','0','0'),(6,9,'1','1','0','0','0','0','0'),(6,10,'0','0','0','0','0','0','0'),(6,11,'0','0','0','0','0','0','0'),(6,12,'0','0','0','0','0','0','0'),(6,13,'0','0','0','0','0','0','0'),(7,1,'1','1','0','1','1','0','0'),(7,2,'1','1','0','1','1','0','0'),(7,3,'0','0','0','1','0','0','0'),(7,4,'0','0','0','1','0','0','0'),(7,5,'1','0','1','1','0','0','0'),(7,6,'1','0','1','1','0','0','0'),(7,7,'1','0','1','0','0','0','0'),(7,8,'1','0','1','0','0','0','0'),(7,9,'0','0','0','0','0','0','0'),(7,10,'1','0','1','1','0','0','0'),(7,11,'1','0','1','0','0','0','0'),(7,12,'0','0','0','0','0','0','0'),(7,13,'0','0','0','0','0','0','0'),(8,1,'1','0','1','1','0','0','0'),(8,2,'1','0','1','1','0','0','0'),(8,3,'1','1','0','0','0','0','0'),(8,4,'1','1','0','0','0','0','0'),(8,5,'1','1','1','1','0','0','0'),(8,6,'1','1','1','1','0','0','0'),(8,7,'1','1','1','1','0','0','0'),(8,8,'1','1','1','1','0','0','0'),(8,9,'1','1','0','0','0','0','0'),(8,10,'1','0','1','0','0','0','0'),(8,11,'1','0','1','0','0','0','0'),(8,12,'0','0','0','0','0','0','0'),(8,13,'0','0','0','0','0','0','0'),(9,1,'0','0','0','0','0','0','0'),(9,2,'0','0','0','0','0','0','0'),(9,3,'0','0','1','1','0','0','0'),(9,4,'0','0','1','1','0','0','0'),(9,5,'1','0','0','1','1','0','0'),(9,6,'1','0','0','1','1','0','0'),(9,7,'1','1','0','1','1','0','0'),(9,8,'1','1','0','1','1','0','0'),(9,9,'0','0','0','1','0','0','0'),(9,10,'0','1','0','0','0','0','0'),(9,11,'0','1','0','0','0','0','0'),(9,12,'0','1','0','0','0','0','0'),(9,13,'0','0','0','0','0','0','0'),(10,1,'0','1','1','0','0','0','0'),(10,2,'0','1','0','0','0','0','0'),(10,3,'1','1','0','1','1','0','0'),(10,4,'1','1','0','1','1','0','0'),(10,5,'0','0','1','0','0','0','0'),(10,6,'0','0','1','0','0','0','0'),(10,7,'1','1','1','0','0','0','0'),(10,8,'1','1','1','0','0','0','0'),(10,9,'0','1','1','0','0','0','0'),(10,10,'0','1','0','0','0','0','0'),(10,11,'0','1','0','0','0','0','0'),(10,12,'0','0','1','0','0','0','0'),(10,13,'0','0','1','0','0','0','0'),(11,1,'0','1','1','0','1','0','0'),(11,2,'0','1','1','0','1','0','0'),(11,3,'0','1','1','0','0','0','0'),(11,4,'0','1','1','0','0','0','0'),(11,5,'1','0','1','0','0','0','0'),(11,6,'1','0','1','0','0','0','0'),(11,7,'1','1','1','1','1','0','0'),(11,8,'1','1','1','1','1','0','0'),(11,9,'0','1','0','0','1','0','0'),(11,10,'1','0','1','1','0','0','0'),(11,11,'1','0','1','1','0','0','0'),(11,12,'0','0','0','0','0','0','0'),(11,13,'0','0','0','0','0','0','0');

/*Table structure for table `db_users` */

DROP TABLE IF EXISTS `db_users`;

CREATE TABLE `db_users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `stuNum` char(12) NOT NULL,
  `stuName` char(8) NOT NULL,
  `depid` int(10) unsigned DEFAULT NULL,
  `grdid` int(10) unsigned DEFAULT NULL,
  `collageid` int(10) unsigned DEFAULT NULL,
  `passwords` varchar(50) NOT NULL,
  `phone` char(14) DEFAULT NULL,
  `sex` smallint(1) NOT NULL,
  `short_phone` char(8) DEFAULT NULL,
  `isWaitForPass` tinyint(1) DEFAULT '0',
  `roleid` int(10) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_id` (`id`),
  KEY `fk_grdid` (`grdid`),
  KEY `fk_depid` (`depid`),
  KEY `fk_collageid` (`collageid`),
  KEY `FK_userRoleid` (`roleid`),
  CONSTRAINT `fk_collageid` FOREIGN KEY (`collageid`) REFERENCES `db_collage` (`collageid`) ON UPDATE CASCADE,
  CONSTRAINT `fk_depid` FOREIGN KEY (`depid`) REFERENCES `db_department` (`depid`) ON UPDATE CASCADE,
  CONSTRAINT `fk_grdid` FOREIGN KEY (`grdid`) REFERENCES `db_grade` (`grdid`) ON UPDATE CASCADE,
  CONSTRAINT `FK_userRoleid` FOREIGN KEY (`roleid`) REFERENCES `db_role` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=gb2312;

/*Data for the table `db_users` */

insert  into `db_users`(`id`,`stuNum`,`stuName`,`depid`,`grdid`,`collageid`,`passwords`,`phone`,`sex`,`short_phone`,`isWaitForPass`,`roleid`) values (1,'0701030091','魏嘉鹏',1,1,1,'958e5d667ceb9f384cbb73672b65cbb2','13750057567',1,'677567',1,2),(2,'0701030089','王哲',2,1,1,'0701030089','',1,'677567',1,3),(3,'0803050089','张晓',2,2,1,'0803050089','15689934545',1,NULL,1,3),(4,'0907030067','望天',5,3,1,'0907030067','19878123234',1,NULL,1,3),(5,'1005020073','曾秀兰',3,4,2,'32dc97e7d136480d143a576bdb1b15c1','',0,'677567',1,5),(6,'0905010115','吴文致',7,3,2,'8b64408006a4d4c418e1729d735dafa1','15689934545',0,'677567',1,3),(7,'1011030022','高亦诚',4,4,2,'1011030022','',1,'677567',1,3),(8,'1011030053','林楚生',7,4,3,'0ee1781e7bfe7e53a0babb2ff079380a','',1,'677567',1,6),(9,'1018010074','梁承业',3,4,4,'1018010074','15689934545',1,'',1,3),(10,'1012010140','黑远',1,4,5,'1012010147','',0,'677567',1,7),(11,'1017030047','倪泽苗',3,4,6,'1017030047','',0,'677567',1,5),(13,'1017030048','张东',3,6,1,'zhangdong','13750057567',1,NULL,1,3),(14,'1017030049','张锡',2,6,2,'zhangxixi','13750057567',0,NULL,0,3),(15,'1017030050','张北',2,6,6,'zhangbei','13750057567',1,NULL,0,3),(16,'1017030051','张楠',7,6,3,'1017030050','13750057567',1,NULL,0,3),(17,'1017030052','张霞',7,6,5,'1017030052','13750057567',0,NULL,0,3),(18,'1017030053','张斌',7,6,4,'1017030053','13750057567',0,NULL,0,3),(19,'1017030054','佛西',2,6,1,'1017030054','13750057567',1,'677567',0,3),(20,'1017030055','佛东',2,6,2,'1017030055','13750057567',1,NULL,0,3),(21,'1017030056','佛北',2,6,5,'81d715ecf9d3e4bb6b304a3d90d1db4a','13750057567',1,NULL,1,3),(22,'1017030056','北东',2,6,4,'81d715ecf9d3e4bb6b304a3d90d1db4a','13750057567',1,NULL,1,3),(23,'1017030056','东部',2,6,4,'81d715ecf9d3e4bb6b304a3d90d1db4a','13750057567',1,NULL,1,3),(24,'1017030058','西西',2,6,4,'e7dfee550b6034b1f699c6ea9232ef67','13750057567',0,NULL,0,3),(25,'1017030059','东东',3,6,4,'e7dfee550b6034b1f699c6ea9232ef67','13750057567',0,NULL,1,3),(26,'1017030070','清水',3,6,4,'fcfa7b51f65d47fe7b1ab3d4c94e9b28','13750057567',0,NULL,1,3);

/*Table structure for table `db_visitapply` */

DROP TABLE IF EXISTS `db_visitapply`;

CREATE TABLE `db_visitapply` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stuNum` char(12) NOT NULL,
  `stuName` char(8) NOT NULL,
  `phone` char(14) NOT NULL,
  `weiboId` char(20) DEFAULT NULL,
  `activityId` int(11) NOT NULL,
  `applytime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_db_visitapply` (`activityId`),
  CONSTRAINT `FK_db_visitapply` FOREIGN KEY (`activityId`) REFERENCES `db_activity` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=gb2312;

/*Data for the table `db_visitapply` */

insert  into `db_visitapply`(`id`,`stuNum`,`stuName`,`phone`,`weiboId`,`activityId`,`applytime`) values (1,'1005020073','曾秀兰','677567',NULL,6,'2012-11-11 14:06:32'),(3,'0905010115','吴文致','677567',NULL,8,'2012-12-17 19:23:13'),(4,'1011030022','高亦诚','677567',NULL,9,'2012-12-18 19:19:44'),(5,'1011030053','林楚生','677567',NULL,9,'2012-12-18 19:24:25'),(6,'1018010074','梁承业','677567',NULL,9,'2012-12-18 19:25:35');

/*Table structure for table `db_visitor_comment` */

DROP TABLE IF EXISTS `db_visitor_comment`;

CREATE TABLE `db_visitor_comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `visitorName` varchar(16) NOT NULL,
  `vositorComment` varchar(200) NOT NULL,
  `commentDatetime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

/*Data for the table `db_visitor_comment` */

/*Table structure for table `db_work` */

DROP TABLE IF EXISTS `db_work`;

CREATE TABLE `db_work` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `userid` int(10) unsigned NOT NULL,
  `content` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `cutOffDate` datetime NOT NULL,
  `statuss` tinyint(4) NOT NULL DEFAULT '1',
  `improveContent` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `improveCutOffDate` datetime DEFAULT NULL,
  `activityid` int(11) NOT NULL,
  `startDate` datetime NOT NULL,
  `improveDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_work_user` (`userid`),
  KEY `fk_work_activity` (`activityid`),
  CONSTRAINT `fk_work_activity` FOREIGN KEY (`activityid`) REFERENCES `db_activity` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_work_user` FOREIGN KEY (`userid`) REFERENCES `db_users` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `db_work` */

insert  into `db_work`(`id`,`userid`,`content`,`cutOffDate`,`statuss`,`improveContent`,`improveCutOffDate`,`activityid`,`startDate`,`improveDate`) values (2,1,'开发网站,吃吃饭','2012-11-30 00:00:00',1,'','2012-11-01 00:00:00',1,'2012-10-01 00:00:00','2012-10-16 00:00:00'),(3,1,'开发网站,吃吃饭，走一走','2012-09-10 00:00:00',4,'','0001-01-01 00:00:00',1,'2012-09-01 00:00:00',NULL),(4,1,'开发网站,吃吃饭，走一走','2010-10-01 00:00:00',8,'','0001-01-01 00:00:00',1,'2010-09-01 00:00:00',NULL),(6,6,'开发网站,吃吃饭，走一走','2012-10-18 00:00:00',1,NULL,NULL,1,'2012-10-10 00:00:00',NULL),(7,6,'开发网站,吃吃饭，走一走','2012-10-20 00:00:00',4,NULL,NULL,1,'2012-10-10 00:00:00',NULL),(8,6,'开发网站,吃吃饭，走一走','2012-10-20 00:00:00',8,NULL,NULL,1,'2012-10-10 00:00:00',NULL),(10,9,'开发网站吃吃吃吃吃吃开发网站吃吃吃吃吃吃','2012-11-12 00:00:00',1,NULL,NULL,1,'2012-11-04 00:00:00',NULL);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
