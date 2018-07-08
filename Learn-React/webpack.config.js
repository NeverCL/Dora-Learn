const CleanWebpackPlugin = require('clean-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

const path = require('path');

module.exports = {
    mode: 'development',
    entry: {
        main: './src/index.js',
    },
    devtool: 'inline-source-map',
    devServer: {
        contentBase: './dist',
        historyApiFallback: true
        // host: '192.168.0.75'
    },
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: '[name].js',
    },
    module: {
        rules: [{
            test: /\.css$/,
            use: [
                MiniCssExtractPlugin.loader,
                'css-loader'
            ]
        }, {
            test: /\.(js|jsx)$/,
            loader: 'babel-loader',
            options: {
                presets: ['react'],
                plugins: [
                    ["import", { "libraryName": "antd", "style": "css" }]
                ]
            },
            exclude: /node_modules/
        }, {
            test: /\.(png|jpg|gif)$/,
            use: [
                {
                    loader: 'file-loader',
                    options: { outputPath: 'static', publicPath: 'static' }
                }
            ]
        }]
    },
    plugins: [
        new CleanWebpackPlugin(['dist']),
        new HtmlWebpackPlugin({ minify: true, hash: true }),
        new MiniCssExtractPlugin({ filename: "[name].css", chunkFilename: "[id].css" }),
    ],
    optimization: {
        splitChunks: {
            cacheGroups: {
                common: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "common",
                    chunks: "initial",
                    enforce: true
                },
            }
        }
    }
};