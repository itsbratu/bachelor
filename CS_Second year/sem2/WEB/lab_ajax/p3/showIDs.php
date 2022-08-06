<?php

$db = new PDO("sqlite:persons.db");
$sql = "SELECT id FROM persons";
$stmt = $db->prepare($sql);
$stmt->execute();
$result = $stmt->fetchAll();

echo "<select id=\"select\" onchange=\"showForm(this.value)\">";

foreach ($result as $row) {
  echo "<option value=\"" . $row["id"] . "\"> " . $row["id"] . " </option>";
}

echo "</select>";

?>