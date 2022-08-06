<?php

$db = new PDO("sqlite:persons.db");
$sql = "SELECT * FROM persons";
$stmt = $db->prepare($sql);
$stmt->execute();
$result = $stmt->fetchAll();

echo "<table>";

$count = 0;
$isThereMore = 0;
$atBeginning = 0;
if($_GET['id'] == 0)
  $atBeginning = 1;

foreach($result as $person){

  if($count < $_GET['id'] * 3);
  else {
    if($count < ($_GET['id']+1) *3){
      echo "<tr>";
      echo "<td>" . $person[0] . "</td>";
      echo "<td>" . $person[1] . "</td>";
      echo "<td>" . $person[2] . "</td>";
      echo "<td>" . $person[3] . "</td>";
      echo "</tr>";
    }
    else { 
      $isThereMore = 1;
    }
  }
  $count = $count + 1;
}

echo "</table>";
if($atBeginning == 1)
  echo "<button disabled onclick=\"prev()\"> Prev </button>";
else
  echo "<button onclick=\"prev()\"> Prev </button>";
if($isThereMore == 0)
  echo "<button disabled onclick=\"next()\"> Next </button>";
else
  echo "<button onclick=\"next()\"> Next </button>";

?>