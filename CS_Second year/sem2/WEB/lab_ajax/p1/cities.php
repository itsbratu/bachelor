<?php

$db = new PDO("sqlite:cities.db");

$sql = "SELECT city2 FROM routes WHERE city1 = :city";

$stmt = $db->prepare($sql);
$stmt->bindParam(':city', $_GET['c'], PDO::PARAM_STR);
$stmt->execute();
$result = $stmt->fetchAll();

echo "<select multiple>";
foreach ($result as $city) {
    echo "<option value=city>" . $city["city2"] . "</option>";
}
echo "</select>";

?>