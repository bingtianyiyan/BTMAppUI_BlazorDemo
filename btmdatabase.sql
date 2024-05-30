/*
 Navicat Premium Data Transfer

 Source Server         : 127.0.0.1
 Source Server Type    : MySQL
 Source Server Version : 50727
 Source Host           : localhost:3306
 Source Schema         : btmdatabase

 Target Server Type    : MySQL
 Target Server Version : 50727
 File Encoding         : 65001

 Date: 30/05/2024 17:29:16
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for monthlyreport
-- ----------------------------
DROP TABLE IF EXISTS `monthlyreport`;
CREATE TABLE `monthlyreport`  (
  `Month` int(11) NULL DEFAULT NULL,
  `TotalAmount` decimal(18, 4) NULL DEFAULT NULL,
  `ProductCounts` int(11) NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for monthlyreportauditlog
-- ----------------------------
DROP TABLE IF EXISTS `monthlyreportauditlog`;
CREATE TABLE `monthlyreportauditlog`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreationDate` datetime(0) NULL DEFAULT NULL,
  `MessageLog` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for productimages
-- ----------------------------
DROP TABLE IF EXISTS `productimages`;
CREATE TABLE `productimages`  (
  `Image_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Image` longblob NULL,
  `Product_Id` int(11) NULL DEFAULT NULL,
  `File_Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Image_Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products`  (
  `Product_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Product_Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Price` decimal(18, 4) NULL DEFAULT NULL,
  `Date_Modified` datetime(0) NULL DEFAULT NULL,
  `Date_Added` datetime(0) NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `QuantityPerUnit` int(11) NULL DEFAULT NULL,
  `Date_Removed` datetime(0) NULL DEFAULT NULL,
  `Category_id` int(11) NULL DEFAULT NULL,
  `Subcategory_id` int(11) NULL DEFAULT NULL,
  `PrimaryImage` varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Product_Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `UserName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Role` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
