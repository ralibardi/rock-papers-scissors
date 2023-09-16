import webpack from "webpack";
import merge from "webpack-merge";
import baseConfig from "./webpack.config";

const config: webpack.Configuration = merge(baseConfig, {
  mode: "production",
  devtool: "source-map",
  output: {
    filename: "[hash].main.js",
  },
});

export default config;
