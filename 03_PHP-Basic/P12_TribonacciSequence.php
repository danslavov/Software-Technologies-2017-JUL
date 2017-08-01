<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET["num"])) {
    $n = intval($_GET["num"]);
    $previous = 1;
    $current = 0;
    $next = 0;
    $future = 0;
    for ($i = 0; $i < $n; $i++) {
        $future = $next + $previous + $current;
        $previous = $current;
        $current = $next;
        $next = $future;
        if ($i < 1) {
            echo "1 ";
        }
        else {
            echo "$next ";
        }
    }
}
?>
</body>
</html>