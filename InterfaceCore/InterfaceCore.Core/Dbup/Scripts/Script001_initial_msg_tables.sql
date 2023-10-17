create table if not exists msg
(
    id int auto_increment primary key,
    region text not null,
    phone int not null,
    description text not null
) engine=innodb default charset=utf8mb4;