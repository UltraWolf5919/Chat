-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 08 2021 г., 09:06
-- Версия сервера: 5.7.31
-- Версия PHP: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `aes`
--

-- --------------------------------------------------------

--
-- Структура таблицы `client_auth`
--

DROP TABLE IF EXISTS `client_auth`;
CREATE TABLE IF NOT EXISTS `client_auth` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FIO` text NOT NULL,
  `Login` varchar(32) NOT NULL,
  `Password` varchar(16) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `client_auth`
--

INSERT INTO `client_auth` (`id`, `FIO`, `Login`, `Password`) VALUES
(1, 'Алексин Андрей Андреевич', 'client123', 'asdf');

-- --------------------------------------------------------

--
-- Структура таблицы `contacts`
--

DROP TABLE IF EXISTS `contacts`;
CREATE TABLE IF NOT EXISTS `contacts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FIO` varchar(100) NOT NULL,
  `Position` varchar(100) NOT NULL,
  `Mail` varchar(100) NOT NULL,
  `Phone_number` bigint(12) NOT NULL,
  `Address` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `contacts`
--

INSERT INTO `contacts` (`id`, `FIO`, `Position`, `Mail`, `Phone_number`, `Address`) VALUES
(1, 'Афонасьев Максим Альбертович', 'Владелец группы компаний \"Axus Group\"', 'Afonasiev_Maxim@axus.name', 89277001122, 'Самара, 443076, ул. Авроры, д.63'),
(2, 'Афонасьев Дмитрий', 'Директор коммерческого отдела', 'afonasievm@axus.name', 89277266423, 'Самара, 443076, ул. Авроры, д.63'),
(3, 'Беляков Игорь Геннадьевич', 'Эксперт в организации системного администрирования для средних и крупных заказчиков', 'belyakovig@axus.name', 89277266423, 'Самара, 443076, ул. Авроры, д.63'),
(4, 'Николаев Евгений Александрович', 'Директор сервисного отдела', 'NikolaevEA@axus.name', 89277064904, 'Самара, 443076, ул. Авроры, д.63'),
(5, 'Старостин Леонид Федорович', 'Практикант', 'avatar5919@gmail.com', 89277238881, 'Самара, 443110, ул. Ново-Садовая, д. 30');

-- --------------------------------------------------------

--
-- Структура таблицы `sotrudnik_auth`
--

DROP TABLE IF EXISTS `sotrudnik_auth`;
CREATE TABLE IF NOT EXISTS `sotrudnik_auth` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FIO` text NOT NULL,
  `Login` text CHARACTER SET utf8 NOT NULL,
  `Password` text CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `sotrudnik_auth`
--

INSERT INTO `sotrudnik_auth` (`id`, `FIO`, `Login`, `Password`) VALUES
(1, 'Сидоров Сергей Сергеевич', 'sotr123', 'qwerty');

-- --------------------------------------------------------

--
-- Структура таблицы `zayavki`
--

DROP TABLE IF EXISTS `zayavki`;
CREATE TABLE IF NOT EXISTS `zayavki` (
  `id` int(11) NOT NULL,
  `Task` varchar(500) NOT NULL,
  `Client` varchar(100) NOT NULL,
  `Worker` varchar(100) NOT NULL,
  `Date_of_issue` date NOT NULL,
  `Request_status` varchar(32) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `zayavki`
--

INSERT INTO `zayavki` (`id`, `Task`, `Client`, `Worker`, `Date_of_issue`, `Request_status`) VALUES
(123125454, 'Установить драйверы на видеокарту', 'Иванов И.И.', 'Сидоров С.С.', '2021-04-18', 'Выполнено'),
(432423525, 'Устранить проблемы с Интернетом', 'Головин Г.Г.', 'Петров П.П.', '2019-03-23', 'В процессе'),
(256333341, 'Устранить проблему подключения к принтеру по локальной сети', 'Державин Д.Д.', 'Зубенко М.Д.', '2021-05-20', 'Выполнено'),
(456879753, 'Подписать производственную практику', 'Леонид', 'Марина', '2021-05-29', 'Выполнено');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
