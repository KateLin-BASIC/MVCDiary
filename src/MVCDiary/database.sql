CREATE DATABASE `diary`;

CREATE TABLE DATA 
(
	  _id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
     title TEXT NOT NULL,
     description TEXT NOT NULL,
     html TEXT NOT NULL,
     date TEXT NOT NULL
) 
ENGINE=INNODB;

INSERT INTO data(title, description, html, date) VALUES ("Hello, World!",  "테스트 설명입니다.","<h1>Hello, World!</h1>", "2020.1.1 12:00");