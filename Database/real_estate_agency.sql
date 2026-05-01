-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Май 01 2026 г., 19:28
-- Версия сервера: 10.4.32-MariaDB
-- Версия PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `real_estate_agency`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `search_properties` (IN `p_min_price` DECIMAL(12,2), IN `p_max_price` DECIMAL(12,2), IN `p_min_area` DECIMAL(8,2), IN `p_max_area` DECIMAL(8,2), IN `p_rooms` SMALLINT, IN `p_district_id` INT, IN `p_property_type_id` INT)   BEGIN
    SELECT 
        p.id,
        p.address,
        p.area,
        p.rooms,
        p.floor,
        p.total_floors,
        p.price,
        p.description,
        p.status,
        d.name AS district,
        pt.name AS property_type,
        o.full_name AS owner_name,
        o.phone AS owner_phone,
        (SELECT photo_path FROM property_photos pp WHERE pp.property_id = p.id AND pp.is_main = TRUE LIMIT 1) AS main_photo
    FROM properties p
    JOIN districts d ON p.district_id = d.id
    JOIN property_types pt ON p.property_type_id = pt.id
    JOIN owners o ON p.owner_id = o.id
    WHERE p.status = 'Свободен'
      AND (p_min_price IS NULL OR p.price >= p_min_price)
      AND (p_max_price IS NULL OR p.price <= p_max_price)
      AND (p_min_area IS NULL OR p.area >= p_min_area)
      AND (p_max_area IS NULL OR p.area <= p_max_area)
      AND (p_rooms IS NULL OR p.rooms = p_rooms)
      AND (p_district_id IS NULL OR p.district_id = p_district_id)
      AND (p_property_type_id IS NULL OR p.property_type_id = p_property_type_id)
    ORDER BY p.created_at DESC;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `registration_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`id`, `full_name`, `phone`, `email`, `registration_date`) VALUES
(1, 'Новиков Максим Олегович', '+79091112233', 'novikov@mail.ru', '2024-01-15'),
(2, 'Федорова Юлия Сергеевна', '+79032223344', 'fedorova@gmail.com', '2024-02-20'),
(3, 'Григорьев Алексей Валерьевич', '+79054445566', 'grigoriev@yandex.ru', '2024-03-10'),
(4, 'Мельникова Ольга Дмитриевна', '+79067778899', 'melnikova@inbox.ru', '2024-03-25'),
(5, 'Зайцев Илья Романович', '+79263339988', 'zaitsev@mail.ru', '2024-04-05');

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `client_favorites_details`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `client_favorites_details` (
`client_id` int(11)
,`client_name` varchar(150)
,`property_id` int(11)
,`address` varchar(255)
,`price` decimal(12,2)
,`area` decimal(8,2)
,`rooms` smallint(6)
,`district` varchar(100)
,`property_type` varchar(50)
,`main_photo` varchar(500)
);

-- --------------------------------------------------------

--
-- Структура таблицы `deals`
--

CREATE TABLE `deals` (
  `id` int(11) NOT NULL,
  `property_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `realtor_id` int(11) NOT NULL,
  `deal_date` date NOT NULL,
  `price` decimal(12,2) NOT NULL,
  `commission` decimal(10,2) NOT NULL,
  `status` varchar(30) DEFAULT 'Завершена'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `deals`
--

INSERT INTO `deals` (`id`, `property_id`, `client_id`, `realtor_id`, `deal_date`, `price`, `commission`, `status`) VALUES
(1, 5, 1, 2, '2024-02-10', 10900000.00, 327000.00, 'Завершена'),
(2, 4, 3, 1, '2024-04-15', 27000000.00, 810000.00, 'Завершена'),
(3, 2, 5, 1, '2026-04-20', 9500000.00, 285000.00, 'Завершена');

--
-- Триггеры `deals`
--
DELIMITER $$
CREATE TRIGGER `update_property_status_after_deal` AFTER INSERT ON `deals` FOR EACH ROW BEGIN
    UPDATE properties 
    SET status = 'Продан' 
    WHERE id = NEW.property_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `districts`
--

CREATE TABLE `districts` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `districts`
--

INSERT INTO `districts` (`id`, `name`) VALUES
(3, 'Заречный'),
(2, 'Ленинский'),
(4, 'Приморский'),
(5, 'Северный'),
(1, 'Центральный');

-- --------------------------------------------------------

--
-- Структура таблицы `favorites`
--

CREATE TABLE `favorites` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `property_id` int(11) NOT NULL,
  `added_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `favorites`
--

INSERT INTO `favorites` (`id`, `client_id`, `property_id`, `added_at`) VALUES
(1, 1, 1, '2026-04-20 14:54:40'),
(2, 1, 3, '2026-04-20 14:54:40'),
(3, 2, 2, '2026-04-20 14:54:40'),
(4, 2, 6, '2026-04-20 14:54:40'),
(5, 3, 4, '2026-04-20 14:54:40'),
(6, 4, 7, '2026-04-20 14:54:40'),
(7, 5, 8, '2026-04-20 14:54:40'),
(8, 5, 1, '2026-04-20 14:54:40'),
(10, 1, 8, '2026-04-29 17:35:40'),
(11, 1, 7, '2026-04-29 17:35:47'),
(13, 1, 6, '2026-04-29 17:51:13');

-- --------------------------------------------------------

--
-- Структура таблицы `owners`
--

CREATE TABLE `owners` (
  `id` int(11) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `passport_data` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `owners`
--

INSERT INTO `owners` (`id`, `full_name`, `phone`, `email`, `passport_data`, `address`) VALUES
(1, 'Кузнецов Андрей Владимирович', '+79031234567', 'kuznetsov@mail.ru', '4512 123456', 'г. Москва, ул. Ленина, д. 10, кв. 5'),
(2, 'Соколова Елена Игоревна', '+79035551234', 'sokolova@yandex.ru', '4615 654321', 'г. Москва, ул. Мира, д. 25, кв. 78'),
(3, 'Морозов Павел Сергеевич', '+79169876543', 'morozov@gmail.com', '4520 987654', 'г. Москва, ул. Пушкина, д. 15'),
(4, 'Волкова Татьяна Алексеевна', '+79261239876', 'volkova@inbox.ru', '4608 112233', 'г. Москва, ул. Гагарина, д. 8, кв. 120');

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `popular_districts_stats`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `popular_districts_stats` (
`district_id` int(11)
,`district_name` varchar(100)
,`total_properties` bigint(21)
,`avg_price` decimal(16,6)
,`min_price` decimal(12,2)
,`max_price` decimal(12,2)
);

-- --------------------------------------------------------

--
-- Структура таблицы `properties`
--

CREATE TABLE `properties` (
  `id` int(11) NOT NULL,
  `owner_id` int(11) NOT NULL,
  `district_id` int(11) NOT NULL,
  `property_type_id` int(11) NOT NULL,
  `address` varchar(255) NOT NULL,
  `area` decimal(8,2) NOT NULL CHECK (`area` > 0),
  `rooms` smallint(6) DEFAULT NULL CHECK (`rooms` >= 0),
  `floor` smallint(6) DEFAULT NULL,
  `total_floors` smallint(6) DEFAULT NULL,
  `price` decimal(12,2) NOT NULL CHECK (`price` >= 0),
  `description` text DEFAULT NULL,
  `status` varchar(30) DEFAULT 'Свободен',
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `properties`
--

INSERT INTO `properties` (`id`, `owner_id`, `district_id`, `property_type_id`, `address`, `area`, `rooms`, `floor`, `total_floors`, `price`, `description`, `status`, `created_at`) VALUES
(1, 1, 1, 1, 'ул. Тверская, д. 15, кв. 45', 78.50, 3, 5, 9, 18500000.00, 'Просторная квартира в центре, евроремонт, мебель', 'Свободен', '2026-04-20 14:54:40'),
(2, 2, 2, 1, 'Ленинский проспект, д. 120, кв. 12', 54.00, 2, 3, 12, 9500000.00, 'Уютная двушка с видом на парк', 'Продан', '2026-04-20 14:54:40'),
(3, 3, 3, 2, 'ул. Лесная, д. 8', 145.00, 5, 1, 2, 32000000.00, 'Кирпичный дом с участком 6 соток, гараж', 'Свободен', '2026-04-20 14:54:40'),
(4, 1, 1, 1, 'ул. Арбат, д. 25, кв. 8', 92.00, 4, 2, NULL, 27500000.00, 'Сталинский дом, высокие потолки, камин', 'Продан', '2026-04-20 14:54:40'),
(5, 4, 4, 1, 'ул. Приморская, д. 30, кв. 67', 65.00, 2, 7, 16, 11200000.00, 'Квартира у моря, новая отделка', 'Продан', '2026-04-20 14:54:40'),
(6, 2, 5, 3, 'Северный бульвар, д. 5, таунхаус 2', 120.00, 4, 1, 2, 18900000.00, 'Таунхаус с отдельным входом и террасой', 'Свободен', '2026-04-20 14:54:40'),
(7, 3, 2, 4, 'Ленинский проспект, д. 100, офис 305', 45.00, 1, 3, 5, 5500000.00, 'Офисное помещение в бизнес-центре', 'Свободен', '2026-04-20 14:54:40'),
(8, 4, 3, 5, 'пос. Солнечный, уч. 15', 850.00, 0, NULL, NULL, 4200000.00, 'Земельный участок ИЖС, коммуникации по границе', 'Свободен', '2026-04-20 14:54:40');

-- --------------------------------------------------------

--
-- Структура таблицы `property_photos`
--

CREATE TABLE `property_photos` (
  `id` int(11) NOT NULL,
  `property_id` int(11) NOT NULL,
  `photo_path` varchar(500) NOT NULL,
  `is_main` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `property_photos`
--

INSERT INTO `property_photos` (`id`, `property_id`, `photo_path`, `is_main`) VALUES
(1, 1, '/photos/prop1_1.jpg', 1),
(2, 1, '/photos/prop1_2.jpg', 0),
(3, 1, '/photos/prop1_3.jpg', 0),
(4, 2, '/photos/prop2_1.jpg', 1),
(5, 2, '/photos/prop2_2.jpg', 0),
(6, 3, '/photos/prop3_1.jpg', 1),
(7, 3, '/photos/prop3_2.jpg', 0),
(8, 4, '/photos/prop4_1.jpg', 0),
(9, 5, '/photos/prop5_1.jpg', 1),
(10, 6, '/photos/prop6_1.jpg', 1),
(11, 7, '/photos/prop7_1.jpg', 1),
(12, 8, '/photos/prop8_1.jpg', 1),
(13, 4, 'D:\\Practice2026\\Practice 3\\Dec\\RealEstateAgency\\RealEstateAgency\\bin\\Debug\\Photos\\6fde15b8-c89d-4c23-bff5-8d0023bf62db.png', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `property_types`
--

CREATE TABLE `property_types` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `property_types`
--

INSERT INTO `property_types` (`id`, `name`) VALUES
(2, 'Дом'),
(5, 'Земельный участок'),
(1, 'Квартира'),
(4, 'Коммерческая недвижимость'),
(3, 'Таунхаус');

-- --------------------------------------------------------

--
-- Структура таблицы `realtors`
--

CREATE TABLE `realtors` (
  `id` int(11) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `login` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role` varchar(20) DEFAULT 'realtor'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `realtors`
--

INSERT INTO `realtors` (`id`, `full_name`, `phone`, `email`, `login`, `password_hash`, `role`) VALUES
(1, 'Иванов Сергей Петрович', '+79161234567', 'ivanov@agency.ru', 'ivanov', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'admin'),
(2, 'Петрова Анна Викторовна', '+79262345678', 'petrova@agency.ru', 'petrova', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'realtor'),
(3, 'Смирнов Денис Игоревич', '+79373456789', 'smirnov@agency.ru', 'smirnov', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'realtor');

-- --------------------------------------------------------

--
-- Структура таблицы `viewing_requests`
--

CREATE TABLE `viewing_requests` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `property_id` int(11) NOT NULL,
  `request_date` date DEFAULT curdate(),
  `preferred_time` varchar(50) DEFAULT NULL,
  `status` varchar(30) DEFAULT 'Новый',
  `comment` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `viewing_requests`
--

INSERT INTO `viewing_requests` (`id`, `client_id`, `property_id`, `request_date`, `preferred_time`, `status`, `comment`) VALUES
(1, 1, 1, '2024-03-01', 'Будни, после 18:00', 'Выполнен', 'Клиент осмотрел, думает'),
(2, 2, 2, '2024-03-15', 'Выходные, первая половина', 'Подтверждён', 'Позвонить за час'),
(3, 3, 3, '2024-04-01', 'Любое', 'Новый', 'Просит срочно показать'),
(4, 4, 6, '2024-04-10', 'Среда или четверг', 'Новый', NULL),
(5, 5, 8, '2024-04-12', 'После обеда', 'Новый', 'Интересуется документами на участок'),
(7, 1, 6, '2020-05-23', '15:33', 'Новый', 'botik');

-- --------------------------------------------------------

--
-- Структура для представления `client_favorites_details`
--
DROP TABLE IF EXISTS `client_favorites_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `client_favorites_details`  AS SELECT `f`.`client_id` AS `client_id`, `c`.`full_name` AS `client_name`, `p`.`id` AS `property_id`, `p`.`address` AS `address`, `p`.`price` AS `price`, `p`.`area` AS `area`, `p`.`rooms` AS `rooms`, `d`.`name` AS `district`, `pt`.`name` AS `property_type`, (select `pp`.`photo_path` from `property_photos` `pp` where `pp`.`property_id` = `p`.`id` and `pp`.`is_main` = 1 limit 1) AS `main_photo` FROM ((((`favorites` `f` join `clients` `c` on(`f`.`client_id` = `c`.`id`)) join `properties` `p` on(`f`.`property_id` = `p`.`id`)) join `districts` `d` on(`p`.`district_id` = `d`.`id`)) join `property_types` `pt` on(`p`.`property_type_id` = `pt`.`id`)) ;

-- --------------------------------------------------------

--
-- Структура для представления `popular_districts_stats`
--
DROP TABLE IF EXISTS `popular_districts_stats`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `popular_districts_stats`  AS SELECT `d`.`id` AS `district_id`, `d`.`name` AS `district_name`, count(`p`.`id`) AS `total_properties`, coalesce(avg(`p`.`price`),0) AS `avg_price`, coalesce(min(`p`.`price`),0) AS `min_price`, coalesce(max(`p`.`price`),0) AS `max_price` FROM (`districts` `d` left join `properties` `p` on(`d`.`id` = `p`.`district_id` and `p`.`status` = 'Свободен')) GROUP BY `d`.`id`, `d`.`name` ORDER BY count(`p`.`id`) DESC ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `phone` (`phone`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Индексы таблицы `deals`
--
ALTER TABLE `deals`
  ADD PRIMARY KEY (`id`),
  ADD KEY `property_id` (`property_id`),
  ADD KEY `client_id` (`client_id`),
  ADD KEY `realtor_id` (`realtor_id`);

--
-- Индексы таблицы `districts`
--
ALTER TABLE `districts`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `favorites`
--
ALTER TABLE `favorites`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_favorite` (`client_id`,`property_id`),
  ADD KEY `property_id` (`property_id`);

--
-- Индексы таблицы `owners`
--
ALTER TABLE `owners`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `phone` (`phone`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Индексы таблицы `properties`
--
ALTER TABLE `properties`
  ADD PRIMARY KEY (`id`),
  ADD KEY `owner_id` (`owner_id`),
  ADD KEY `district_id` (`district_id`),
  ADD KEY `property_type_id` (`property_type_id`);

--
-- Индексы таблицы `property_photos`
--
ALTER TABLE `property_photos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `property_id` (`property_id`);

--
-- Индексы таблицы `property_types`
--
ALTER TABLE `property_types`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `realtors`
--
ALTER TABLE `realtors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `phone` (`phone`),
  ADD UNIQUE KEY `login` (`login`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Индексы таблицы `viewing_requests`
--
ALTER TABLE `viewing_requests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `client_id` (`client_id`),
  ADD KEY `property_id` (`property_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `deals`
--
ALTER TABLE `deals`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `districts`
--
ALTER TABLE `districts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `favorites`
--
ALTER TABLE `favorites`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `owners`
--
ALTER TABLE `owners`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `properties`
--
ALTER TABLE `properties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `property_photos`
--
ALTER TABLE `property_photos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `property_types`
--
ALTER TABLE `property_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `realtors`
--
ALTER TABLE `realtors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `viewing_requests`
--
ALTER TABLE `viewing_requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `deals`
--
ALTER TABLE `deals`
  ADD CONSTRAINT `deals_ibfk_1` FOREIGN KEY (`property_id`) REFERENCES `properties` (`id`),
  ADD CONSTRAINT `deals_ibfk_2` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`),
  ADD CONSTRAINT `deals_ibfk_3` FOREIGN KEY (`realtor_id`) REFERENCES `realtors` (`id`);

--
-- Ограничения внешнего ключа таблицы `favorites`
--
ALTER TABLE `favorites`
  ADD CONSTRAINT `favorites_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `favorites_ibfk_2` FOREIGN KEY (`property_id`) REFERENCES `properties` (`id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `properties`
--
ALTER TABLE `properties`
  ADD CONSTRAINT `properties_ibfk_1` FOREIGN KEY (`owner_id`) REFERENCES `owners` (`id`),
  ADD CONSTRAINT `properties_ibfk_2` FOREIGN KEY (`district_id`) REFERENCES `districts` (`id`),
  ADD CONSTRAINT `properties_ibfk_3` FOREIGN KEY (`property_type_id`) REFERENCES `property_types` (`id`);

--
-- Ограничения внешнего ключа таблицы `property_photos`
--
ALTER TABLE `property_photos`
  ADD CONSTRAINT `property_photos_ibfk_1` FOREIGN KEY (`property_id`) REFERENCES `properties` (`id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `viewing_requests`
--
ALTER TABLE `viewing_requests`
  ADD CONSTRAINT `viewing_requests_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `viewing_requests_ibfk_2` FOREIGN KEY (`property_id`) REFERENCES `properties` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
