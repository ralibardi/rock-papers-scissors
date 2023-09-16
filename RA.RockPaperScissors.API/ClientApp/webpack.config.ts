import path from "path";
import webpack from "webpack";
import ForkTsCheckerWebpackPlugin from "fork-ts-checker-webpack-plugin";
import MiniCssExtractPlugin from "mini-css-extract-plugin";
import HtmlWebpackPlugin from "html-webpack-plugin";

const config: webpack.Configuration = {
  entry: {
    app: path.resolve(__dirname, "src/index.tsx"),
  },
  output: {
    path: path.resolve(__dirname, "build"),
  },
  resolve: {
    extensions: [".js", ".jsx", ".ts", ".tsx"],
  },
  plugins: [
    new ForkTsCheckerWebpackPlugin(),
    new MiniCssExtractPlugin(),
    new HtmlWebpackPlugin({
      title: "Rock Paper Scissors",
      template: "public/index.html",
    }),
  ],
  module: {
    rules: [
      {
        test: /\.(t|j)sx?$/,
        exclude: [/node_modules/, /Scripts/],
        use: [
          {
            loader: "ts-loader",
            options: {
              transpileOnly: true,
            },
          },
        ],
      },
      {
        test: /\.css$/,
        exclude: [/^\.\/Content/],
        use: [MiniCssExtractPlugin.loader, "css-loader"],
      },
      {
        test: /\.scss$/,
        exclude: [/^\.\/Content/],
        use: [
          "style-loader",
          "css-loader",
          "resolve-url-loader",
          "sass-loader",
        ],
      },
      {
        test: /\.svg/,
        exclude: [/^\.\/Content/],
        use: [
          {
            loader: "@svgr/webpack",
            options: {
              svgoConfig: {
                plugins: [
                  { prefixIds: { prefixIds: true, prefixClassNames: false } },
                  { cleanupIDs: false },
                ],
              },
            },
          },
        ],
      },
      {
        test: /\.(woff(2)?|ttf|eot|png)(\?v=\d+\.\d+\.\d+)?$/,
        use: [
          {
            loader: "file-loader",
            options: {
              name: "[path][name].[ext]",
            },
          },
        ],
      },
    ],
  },
};

export default config;
