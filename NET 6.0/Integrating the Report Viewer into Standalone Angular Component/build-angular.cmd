cd ClientApp
set NODE_OPTIONS=--openssl-legacy-provider
call npm i --force
call ng build --output-hashing none
cd ..
