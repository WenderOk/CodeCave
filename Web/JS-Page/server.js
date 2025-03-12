const http = require("http");
const hostname = "127.0.0.1";
const port = 3000;

const server = http.createServer((req, res) => {
  res.statusCode = 200;
  res.setHeader("Content-Type", "text/html; charset=utf-8");
  res.end(`
<html>
  <head>
    <meta charset="UTF-8" />
    <title>JS Page</title>
  </head>
  <body style="background-color: black">
    <h1 style="color: white; text-align: center;">Hello, JavaScript!</h1>
    <p style="color: white; text-align: center;">This is a simple JavaScript webpage.</p>
    <script>
      const currentDate = new Date();
      document.write("Current date and time: " + currentDate);
    </script>
  </body>
</html>
`);
});
server.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});
