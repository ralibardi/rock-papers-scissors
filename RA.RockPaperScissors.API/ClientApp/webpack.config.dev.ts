import webpack from "webpack";
import merge from "webpack-merge";
import baseConfig from "./webpack.config";

const config: webpack.Configuration = merge(baseConfig, {
  mode: "development",
  devtool: "source-map",
  output: {
    filename: "[name].main.js",
  },
});

export default config;
