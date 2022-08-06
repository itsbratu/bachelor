<?php

header('Content-type: text/plain; charset=UTF-8');

$db = new PDO("sqlite:persons.db");
$sql = "SELECT * FROM persons WHERE id = :id";
$stmt = $db->prepare($sql);
$stmt->bindParam(':id', $_GET['id'], PDO::PARAM_INT);
$stmt->execute();
$result = $stmt->fetchAll();

echo "<form>";

foreach ($result as $row) {
  echo "<label for=\"fname\">First name:</label><br>";
  echo "<input type=\"text\" id=\"fname\" name=\"fname\" value=" . $row["first_name"] . "><br>";
  echo "<label for=\"lname\">Last name:</label><br>";
  echo "<input type=\"text\" id=\"lname\" name=\"lname\" value=" . $row["last_name"] . "><br>";
  echo "<label for=\"email\">E-mail::</label><br>";
  echo "<input type=\"text\" id=\"email\" name=\"email\" value=" . $row["email"] . "><br>";
}

echo "<input type=\"submit\" value=\"Submit\" onclick=\"save()\"";
echo "</form>";


 ?>