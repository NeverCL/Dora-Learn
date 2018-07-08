const CleanWebpackPlugin = require('clean-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const path = require('path');

module.exports = {
    mode: 'production',
    entry: {
        main: './src/index.js',
    },
    devtool: 'source-map',
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
                    "syntax-dynamic-import",
                ]
            },
            exclude: /node_modules/
        }, {
            test: /\.(png|svg|jpg|gif|ico)$/,
            loader: 'file-loader',
            options: {
                publicPath: 'static'
            }
        }]
    },
    plugins: [
        new CleanWebpackPlugin(['dist']),
        new HtmlWebpackPlugin({ template: 'src/index.html', minify: true, hash: true }),
        new MiniCssExtractPlugin({ filename: "[name].css", chunkFilename: "[id].css" }),
    ],
    externals: {
        lodash: '_',
        react: 'React',
        'react-dom': 'ReactDOM',
        antd: 'antd'
    },
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