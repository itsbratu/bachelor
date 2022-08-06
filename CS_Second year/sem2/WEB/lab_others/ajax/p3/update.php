<?php

$db = new PDO("sqlite:persons.db");
$sql = "UPDATE persons SET first_name = :firstName, last_name = :lastName, email = :email WHERE id = :id";
$stmt = $db->prepare($sql);
$stmt->bindParam(':firstName', $_GET['fname'], PDO::PARAM_STR);
$stmt->bindParam(':lastName', $_GET['lname'], PDO::PARAM_STR);
$stmt->bindParam(':email', $_GET['email'], PDO::PARAM_STR);
$stmt->bindParam(':id', $_GET['id'], PDO::PARAM_INT);
$stmt->execute();

 ?>